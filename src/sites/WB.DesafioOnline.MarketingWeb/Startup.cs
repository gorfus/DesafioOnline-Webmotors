using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;
using WB.DesafioOnline.Anuncios.Core;
using WB.DesafioOnline.MarketingWeb.Integracoes.Anuncios;
using WB.DesafioOnline.MarketingWeb.Integracoes.OnlineChallenge;

namespace WB.DesafioOnline.MarketingWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IAnunciosServicos, AnunciosServicos>();

            // API Webmotors: acessando os dados de marcas,modelos,versoes e veiculos da Webmotors
            services.AddHttpClient<IInformacoesCarrosServicos, InformacoesCarrosServicos>("onlinechallenge", c =>
            {
                c.BaseAddress = new Uri("https://desafioonline.webmotors.com.br/api/onlinechallenge/");
            }).AddPolicyHandler(PollyExtensions.WaitRetry()); ;
            // API local:para fazer o CRUD acessando os Anuncios pela API 
            services.AddHttpClient<IAnunciosServicos, AnunciosServicos>("anunciosapi", c =>
            {
                c.BaseAddress = new Uri("https://localhost:44378/api/Anuncios/");
            }).AddPolicyHandler(PollyExtensions.WaitRetry());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> WaitRetry()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(7),
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentantiva num: {retryCount}!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            return retry;
        }
    }

}

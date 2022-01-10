using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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

            // API local:para fazer o CRUD acessando os Anuncios pela API 
            services.AddHttpClient<IInformacoesCarrosServicos, InformacoesCarrosServicos>("onlinechallenge", c =>
            {
                c.BaseAddress = new Uri("https://desafioonline.webmotors.com.br/api/onlinechallenge/");
            });

            // API Webmotors: acessando os dados de marcas,modelos,versoes e veiculos da Webmotors
            services.AddHttpClient<IAnunciosServicos, AnunciosServicos>("anunciosapi", c =>
            {
                c.BaseAddress = new Uri("https://localhost:44378/api/Anuncios/");
            });

            //services.AddHttpClient<IInformacoesCarrosServicos, InformacoesCarrosServicos>()
            //.AddPolicyHandler(PollyExtensions.EsperarTentar())
            //.AddTransientHttpErrorPolicy(
            //    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)))
            ;
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
}

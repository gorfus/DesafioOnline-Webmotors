using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WB.DesafioOnline.Anuncios.Dominio;

namespace WB.DesafioOnline.Anuncios.Data.Mapeamentos
{
    public class AnuncioMapping : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(c => c.AnuncioId);

            builder.Property(c => c.Marca)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(c => c.Modelo)
             .IsRequired()
             .HasColumnType("varchar(45)");

            builder.Property(c => c.Versao)
              .IsRequired()
              .HasColumnType("varchar(45)");

            builder.Property(c => c.Ano)
              .IsRequired();

            builder.Property(c => c.Quilometragem)
             .IsRequired();

            builder.Property(c => c.Observacao)
             .IsRequired()
             .HasColumnType("text");

            builder.ToTable("tb_AnuncioWebmotors");
        }
    }
}
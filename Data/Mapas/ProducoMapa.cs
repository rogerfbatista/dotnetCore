using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using catagoloproduto.Models;

namespace catagoloproduto.Data.Mapas
{
    public class ProdutoMapa : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.Imagem).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.DataUltimaAlteracao).IsRequired();
            builder.Property(x => x.Preco).IsRequired().HasColumnType("money");
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos);
        }
    }
}
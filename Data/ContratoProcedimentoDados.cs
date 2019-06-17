using Microsoft.EntityFrameworkCore;
using catagoloproduto.Models;
using catagoloproduto.Data.Mapas;
namespace catagoloproduto.Data
{
    public class ContratoProcedimentoDados : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=192.168.0.112;Initial Catalog=lojaProdutos;Persist Security Info=True;User ID=sa;Password=123456");
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=lojaProdutos;User ID=sa;Password=123456");
            //optionsBuilder.UseSqlServer(@"Server=192.168.1.112,1433;Database=lojaProdutos;User ID=sa;Password=123456");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoMapa());
            builder.ApplyConfiguration(new CategoriaMapa());
        }
    }
}
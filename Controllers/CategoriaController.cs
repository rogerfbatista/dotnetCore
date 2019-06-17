using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using catagoloproduto.Data;
using catagoloproduto.Models;
using System.Threading.Tasks;

namespace catagoloproduto.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ContratoProcedimentoDados _context;

        public CategoriaController(ContratoProcedimentoDados context)
        {
            _context = context;
        }

        [Route("v1/categorias")]
        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        [Route("v2/categorias")]
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetList()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        [Route("v1/Categorias/{id}")]
        [HttpGet]
        public Categoria Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            return _context.Categorias.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/Categorias/{id}/products")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Produto> GetProducts(int id)
        {
            return _context.Produtos.AsNoTracking().Where(x => x.CategoriaId == id).ToList();
        }

        [Route("v1/Categorias")]
        [HttpPost]
        public Categoria Post([FromBody]Categoria category)
        {
            _context.Categorias.Add(category);
            _context.SaveChanges();

            return category;
        }

        [Route("v1/Categorias")]
        [HttpPut]
        public Categoria Put([FromBody]Categoria category)
        {
            _context.Entry<Categoria>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        [Route("v1/Categorias")]
        [HttpDelete]
        public Categoria Delete([FromBody]Categoria category)
        {
            _context.Categorias.Remove(category);
            _context.SaveChanges();

            return category;
        }
    }
}
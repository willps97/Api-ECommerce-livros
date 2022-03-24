using EcommerceAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public livrariaController(ToDoContext context)
        {
            _context = context;

            _context.ToDoProducts.Add(new Produto { Id = "1", Nome = "Book1", Preco = 24.0, Quantidade = 1, Categoria = "Ação", Img = "Img01" });
            _context.ToDoProducts.Add(new Produto { Id = "2", Nome = "Book2", Preco = 10.0, Quantidade = 3, Categoria = "Ação", Img = "Img02" });
            _context.ToDoProducts.Add(new Produto { Id = "3", Nome = "Book3", Preco = 15.0, Quantidade = 10, Categoria = "Ação", Img = "Img03" });
            _context.ToDoProducts.Add(new Produto { Id = "4", Nome = "Book4", Preco = 17.0, Quantidade = 5, Categoria = "Ação", Img = "Img04" });
            _context.ToDoProducts.Add(new Produto { Id = "5", Nome = "Book5", Preco = 20.0, Quantidade = 4, Categoria = "Ação", Img = "Img05" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.ToDoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.ToDoProducts.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.ToDoProducts.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
        }
    }
}

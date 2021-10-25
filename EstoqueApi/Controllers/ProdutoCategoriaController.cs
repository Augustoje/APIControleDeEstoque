using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstoqueApi.Data;
using EstoqueApi.Models;

namespace EstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoCategoriaController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public ProdutoCategoriaController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: api/ProdutoCategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoCategoria>>> GetProdutoCategoria()
        {
            return await _context.ProdutoCategoria.ToListAsync();
        }

        // GET: api/ProdutoCategoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoCategoria>> GetProdutoCategoria(int id)
        {
            var produtoCategoria = await _context.ProdutoCategoria.FindAsync(id);

            if (produtoCategoria == null)
            {
                return NotFound();
            }

            return produtoCategoria;
        }

        // PUT: api/ProdutoCategoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoCategoria(int id, ProdutoCategoria produtoCategoria)
        {
            if (id != produtoCategoria.ID)
            {
                return BadRequest();
            }

            _context.Entry(produtoCategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoCategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProdutoCategoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutoCategoria>> PostProdutoCategoria(ProdutoCategoria produtoCategoria)
        {
            _context.ProdutoCategoria.Add(produtoCategoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoCategoria", new { id = produtoCategoria.ID }, produtoCategoria);
        }

        // DELETE: api/ProdutoCategoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoCategoria(int id)
        {
            var produtoCategoria = await _context.ProdutoCategoria.FindAsync(id);
            if (produtoCategoria == null)
            {
                return NotFound();
            }

            _context.ProdutoCategoria.Remove(produtoCategoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoCategoriaExists(int id)
        {
            return _context.ProdutoCategoria.Any(e => e.ID == id);
        }
    }
}

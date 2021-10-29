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
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }
        // consultando todos os produtos e suas respectivas categorias
        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {

            var produtos = await _context.Produto.Include(a => a.Categoria).ToListAsync();

            return produtos;
        }

        //Consulta quantidade de produto em estoque
        [HttpGet("Quantidade-Estoque")]

        public async Task<ActionResult<List<Produto>>> GetEstoque()
        {
            List<Produto> Produto = new List<Produto>();

            var estoques = await _context.Produto.Where(a => a.ID == Produto.id).ToListAsync;
            int estoqueQuantidade = 0;
            foreach(var estoque in estoques)
            {
                estoqueQuantidade += estoque.Quantidade;
            }

            return estoques;

        //Consulta do Produto por ID
        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoPorCodigo(int id)
        {
            var produto = await _context.Produto.Where(c => c.ID == id).FirstOrDefaultAsync();


            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produto/5
        [HttpPut]
        public async Task<IActionResult> PutProduto( Produto produto)
        {

            _context.Entry(produto).State = EntityState.Modified;
            _context.Entry(produto.Categoria).State = EntityState.Unchanged;  

                await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT Selecionando o ID e adicionando a quantidade do produto, subtraindo a quantidade em estoque
        // PUT: api/Produto
        //
        [HttpPatch("Produto/{id}/Compra/quantidade/{quantidade}")]
        public async Task<IActionResult> PutQtdProduto([FromRoute] int id, [FromRoute] int quantidade)
        {
            var Compra = new Produto() { ID = id, quantidade = quantidade }; 

           var meuProduto = await _context.Produto.AsNoTracking().Where(c => c.ID == Compra.ID).FirstOrDefaultAsync();
            meuProduto.quantidade = meuProduto.quantidade + Compra.quantidade;
            _context.Produto.Attach(meuProduto);
            _context.Entry(meuProduto).Property(c => c.quantidade).IsModified = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {

            _context.Produto.Add(produto);
            _context.Entry(produto.Categoria).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetProduto", new { id = produto.ID }, produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.ID == id);
        }
    }
}

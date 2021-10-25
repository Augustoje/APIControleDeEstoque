using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstoqueApi.Models;

namespace EstoqueApi.Data
{
    public class ProdutoContext : DbContext
    {

        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }


    }
}

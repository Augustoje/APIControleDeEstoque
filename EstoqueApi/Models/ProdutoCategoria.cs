using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueApi.Models
{
    public class ProdutoCategoria
    {
        public int ID { get; set; }
        public ICollection<Produto> Produto { get; set; }
        public int ProdutosID { get; set; }
        public ICollection<Categoria> Categoria { get; set; }
        public int categoriasID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueApi.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string nomecategoria { get; set; }
        public ProdutoCategoria produtoCategoria { get; set; }

    }
}


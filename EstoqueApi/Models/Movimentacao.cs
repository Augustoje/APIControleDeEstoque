using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueApi.Models
{
    public class Movimentacao
    {
        public int ID { get; set; }
        public Produto Produto { get; set; }
        public int produtoID { get; set; }
        public string descricoes { get; set; }
        public string data { get; set; }
    }
}

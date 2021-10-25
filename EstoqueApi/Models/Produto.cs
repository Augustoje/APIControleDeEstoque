﻿using System.Collections.Generic;

namespace EstoqueApi.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public int codigo { get; set; }
        public string nome { get; set; }
        public string modelo { get; set; }
        public int quantidade { get; set; }
        public string descricao { get; set; }
        public string tamanho { get; set; }
        public double preco { get; set; }
        public string imagem { get; set; }
        public ProdutoCategoria ProdutoCategoria { get; set; }
        public int categoriaID { get; set; }
        public ICollection<Movimentacao> Movimentacao { get; set; }


    }
}


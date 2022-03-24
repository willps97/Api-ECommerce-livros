﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPIs.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
        public string Img { get; set; }
    }
}

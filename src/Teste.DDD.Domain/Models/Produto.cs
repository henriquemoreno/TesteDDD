﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.DDD.Domain.Models
{
    public class Produto : Entity
    {
        public Produto()
        {
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
    }
}

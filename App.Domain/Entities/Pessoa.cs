﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateOnly DataAniversario { get; set; }
        public int CPF { get; set; }

        public string Senha { get; set; }
        
    }
}

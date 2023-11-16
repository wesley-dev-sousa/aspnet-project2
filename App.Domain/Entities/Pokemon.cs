using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Level { get; set; }
        public List<String> Tipo { get; set; }
    }
}

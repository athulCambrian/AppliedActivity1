using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedActivity1.Models
{
    internal class Cocktail
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
       

        public Cocktail(string name, string instructions)
        {
            Name = name;
            Instructions = instructions;
          
        }
    }
}



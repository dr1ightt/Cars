using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Entites
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
         public List<Mark> Marks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Entites
{
    public class MarkCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int MarkId { get; set; }


        public Car Car { get; set; }
        public Mark Mark { get; set; }
    }
}

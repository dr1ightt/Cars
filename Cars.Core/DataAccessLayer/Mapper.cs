using Cars.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Fuel Map(IDataReader reader)
        {
            return new Fuel
            {
                Type = (byte)reader["Type"],
                Id = (int)reader["Id"]
            };
        }
    }
}

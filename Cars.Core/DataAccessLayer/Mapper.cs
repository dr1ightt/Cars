using Cars.Core.Domain.Entites;
using Cars.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Cars.Core.Domain.Enums.Type;

namespace Cars.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Fuel Map(IDataReader reader)
        {
            return new Fuel
            {
                Type = (byte)(Type)reader["Type"],
                Id = (int)reader["Id"]
            };
        }

        public static Car MapCar(IDataReader reader)
        {
            return new Car
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Price = (decimal)reader["Price"],
                Category = (byte)(Category)reader["Category"]
            };
        }

        public static Mark MapMark(IDataReader reader)
        {
            return new Mark
            {
                Id= (int)reader["Id"],
                Name= (string)reader["Name"]
            };
        }

        public static MarkCar MapMarkCar(IDataReader reader)
        {
            return new MarkCar
            {
                Id = (int)reader["Id"],
                CarId = (int)reader["CarID"],
                Car = new Car
                {
                    Id = (int)reader["CarId"],
                    Name = (string)reader["CarName"],
                    Price = (decimal)reader["Price"],
                    Category = (byte)(Category)reader["Category"]
                },

                MarkId = (int)reader["Id"],
                Mark = new Mark
                {
                    Id = (int)reader["MarkId"],
                    Name = (string)reader["MarkName"]
                }

            };
        }


    }
}

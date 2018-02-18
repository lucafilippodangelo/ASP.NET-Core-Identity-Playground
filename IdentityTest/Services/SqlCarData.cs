using IdentityTest.DbContexes;
using IdentityTest.Interfaces;
using IdentityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Services
{
    //LD STEP001
    public class SqlCarData : ICarData
    {
        private ProjectDbContext _context;

        public SqlCarData(ProjectDbContext context)
        {
            _context = context;
        }

        public Car Add(Car newCar)
        {
            _context.Add(newCar);
            _context.SaveChanges();
            return newCar;
        }

        public Car Get(int id)
        {
            return _context.Cars.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList ();
        }
    }

}




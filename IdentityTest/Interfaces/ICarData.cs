using IdentityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Interfaces
{
    //LD STEP001
    public interface ICarData
    {
        IEnumerable<Car> GetAll();
        Car Get(int id);
        Car Add(Car newRestaurant);
    }
}






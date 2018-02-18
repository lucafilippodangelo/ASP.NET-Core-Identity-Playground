using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityTest.Interfaces;
using IdentityTest.Models;

namespace IdentityTest.Controllers
{
    public class HomeController : Controller
    {
        private ICarData _carData;

        public HomeController(ICarData carData) //LD dependency injection
        {
            _carData = carData;
        }

        public IActionResult Index()
        {

            var model = new Car();
            var allCar = _carData.GetAll();

            model.brand = _carData.Get(3).brand;
            return View(model);

        }


        //public IActionResult Details(int id)
        //{
        //    var model = _restaurantData.Get(id);
        //    if (model == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(model);
        //}
    }
}

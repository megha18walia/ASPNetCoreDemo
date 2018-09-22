using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASpNetCore.Model;
using TestASpNetCore.ViewModel;

namespace TestASpNetCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IRestaurant restaurant;
        IGreeting greet;
        public HomeController(IRestaurant objRes, IGreeting greeting)
        {
            restaurant = objRes;
            greet = greeting;
        }
        public IActionResult Index()
        {

            var Model = new HomeViewModel();
            Model.CurrentMessage = greet.GetMessage();
            Model.Restaurants = restaurant.GetRestaurants();
            return View(Model);
        }

        public IActionResult Details(int id)
        {
            var result = restaurant.GetDetail(id);
            if (result == null)
                return RedirectToAction(nameof(Index));
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantViewModel RVM)
        {
            if (ModelState.IsValid)
            {
                Restaurant R = new Restaurant
                {
                    Name = RVM.Name,
                    Cuisine = RVM.Cuisine
                };

                R = restaurant.AddRes(R);
                // return View("Details", R);

                //To Fix the problem with above code
                return RedirectToAction("Details", new { id = R.ID });
            }
            else
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestASpNetCore.Model;

namespace TestASpNetCore.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IRestaurant dbContext;

        public EditModel(IRestaurant rest)
        {
            dbContext = rest;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = dbContext.GetDetail(id);
            if(Restaurant == null)
            {
                RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                dbContext.UpdateRestaurant(Restaurant);
                return RedirectToAction("Details", "Home", new { id = Restaurant.ID });
                
            }
            return Page();

        }
    }
}
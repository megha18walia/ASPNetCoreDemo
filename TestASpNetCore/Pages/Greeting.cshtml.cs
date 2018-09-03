using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestASpNetCore.Pages
{
    public class GreetingModel : PageModel
    {
        public string Message { get; set; }
        private IGreeting _greet;


        public GreetingModel(IGreeting greeting)
        {
            _greet = greeting;
        }

        public void OnGet(string name)
        {
            Message =$"{name} : {_greet.GetMessage()}";
        }
    }
}
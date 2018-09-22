using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASpNetCore.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        IGreeting greet;
        public GreeterViewComponent(IGreeting _greet)
        {
            greet = _greet;
        }

        public IViewComponentResult Invoke()
        {
            var model = greet.GetUser();
            return View("Default", model);
        }
    }
}

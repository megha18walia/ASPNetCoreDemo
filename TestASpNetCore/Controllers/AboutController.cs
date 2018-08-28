using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASpNetCore.Controllers
{

    public class AboutController
    {

        public string Phone()
        {
            return "+91 9988776655";
        }


        public string Address()
        {
            return "Shastri Park";
        }
    }
}

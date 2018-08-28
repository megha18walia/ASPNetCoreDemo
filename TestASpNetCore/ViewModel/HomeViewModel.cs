using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASpNetCore.Model;

namespace TestASpNetCore.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }

    }
}

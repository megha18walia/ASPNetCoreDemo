using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASpNetCore.Model
{
   public  interface IRestaurant
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetDetail(int id);
        Restaurant AddRes(Restaurant Res);
            
    }
}

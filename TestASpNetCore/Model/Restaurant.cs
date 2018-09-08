using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestASpNetCore.Model
{
    public class ImplementRestaurant 
    {
        List<Restaurant> lstRes;
        public ImplementRestaurant()
        {
            lstRes = new List<Restaurant>();
            lstRes.Add(new Restaurant { ID = 1, Name = "Pizza hut" });
            lstRes.Add(new Restaurant { ID = 2, Name = "Dominos" });
            lstRes.Add(new Restaurant { ID = 3, Name = "Mc Donalds" });
        }

        public Restaurant AddRes(Restaurant Res)
        {
            int i = lstRes.Max(p => p.ID);
            i++;
            Res.ID = i;
            lstRes.Add(Res);
            return Res;
        }

        public Restaurant GetDetail(int id)
        {
            return lstRes.FirstOrDefault(d => d.ID == id);
        }

        public List<Restaurant> GetRestaurants()
        {
           
            return lstRes;
        }
    }
    public class Restaurant
    {
        public int ID { get; set; }
        [Display(Name = "Restaurant Name")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASpNetCore.Data;

namespace TestASpNetCore.Model
{
    public class SQLRestaurant : IRestaurant
    {
        SqlDBContext _context;

        public SQLRestaurant(SqlDBContext context)
        {
            _context = context;
        }
        public Restaurant AddRes(Restaurant Res)
        {
            _context.Add(Res);
            _context.SaveChanges();
            return Res;
        }

        public Restaurant GetDetail(int id)
        {
            return _context.Restaurant.Where(p => p.ID == id).SingleOrDefault();
        }

        public List<Restaurant> GetRestaurants()
        {
            return _context.Restaurant.ToList();
        }

        public Restaurant UpdateRestaurant(Restaurant rest)
        {
            _context.Attach(rest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return rest;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASpNetCore.Model;

namespace TestASpNetCore.Data
{
    public class SqlDBContext : DbContext
    {
        public SqlDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurant { get; set; }
    }
}

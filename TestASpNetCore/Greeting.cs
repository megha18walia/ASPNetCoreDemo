using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASpNetCore
{
    public class Greeting : IGreeting
    {
        private IConfiguration config;

        public Greeting(IConfiguration conf)
        {
            config = conf;
        }
        public string GetMessage()
        {
            return config["Greeting"];
        }
    }
}

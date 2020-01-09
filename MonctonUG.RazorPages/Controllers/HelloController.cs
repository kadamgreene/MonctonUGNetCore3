using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.RazorPages.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {
        [Route("/hello/{name}")]
        public string Get(string name)
        {
            return "Hello, " + name;
        }
    }
}

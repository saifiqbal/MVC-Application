using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ceu_Education_MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HelloWorldController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}

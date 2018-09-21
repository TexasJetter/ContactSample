using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contact.Web.Models;

namespace Contact.Web.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}

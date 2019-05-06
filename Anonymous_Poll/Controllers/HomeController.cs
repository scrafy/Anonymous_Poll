using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Anonymous_Poll.Models;
using Anonymous_Poll.Infraestructure.Repositories;

namespace Anonymous_Poll.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AlumnsRepository repository = new AlumnsRepository();
            string resp = repository.search(new InputCase()
            {
                AcademicYear = 2,
                Gender = 'F',
                Age = 20,
                Studies = "Systems Engineering"
            });
           return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

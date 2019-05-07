using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anonymous_Poll.Infraestructure.Binders;
using Anonymous_Poll.Infraestructure.Interfaces;
using Anonymous_Poll.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anonymous_Poll.Controllers
{
    public class SurveyController : Controller
    {
        private I_AlumnsRepository repository = null;


        public SurveyController(I_AlumnsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Search([ModelBinder(BinderType = typeof(InputCaseModelBinder))]Input input)
        {
            string[] results = new string[input.Total];
            int cont = 0;
            foreach(InputCase input_case in input.InputCases)
            {
                string result = this.repository.search(input_case);
                results[cont] = result != null ? String.Format("Case #{0}: {1}", cont, result) : String.Format("Case #{0}: NONE", cont);
                cont++;
            }
            this.ViewBag.Data = results;
            return View();
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Error()
        {
            return View();
        }
    }
}

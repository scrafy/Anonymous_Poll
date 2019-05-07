using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Anonymous_Poll.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anonymous_Poll.Infraestructure.Binders
{
    public class InputCaseModelBinder : IModelBinder
    {
        public InputCaseModelBinder()
        {
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            string input = null;
            string[] cases = null;
            UInt16 num_cases = 0;
            List<InputCase> inputCases = new List<InputCase>();
            input = bindingContext.HttpContext.Request.Form["input"];
            input = input.Replace("\r", "");
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("The body is empty...");
            }

            cases = input.Split(new char[] { '\n' });
            num_cases = Convert.ToUInt16(cases[0]);
            Array.Reverse(cases);
            Array.Resize(ref cases, cases.Length - 1);
            Array.Reverse(cases);
            if (num_cases != cases.Length)
            {
                throw new Exception("The number of input cases is not correct...");
            }
            foreach (string _case in cases){

                if (Regex.IsMatch(_case, @"^([M,F]{1}),([1-9][0-9]?|100),([a-zA-Z\s]+),([1-9][0-9]?|100)$"))
                {
                    string[] data = _case.Split(new char[] { ',' });
                    inputCases.Add(new InputCase()
                    {
                        Studies = data[2],
                        Age = Convert.ToUInt16(data[1]),
                        Gender = Convert.ToChar(data[0]),
                        AcademicYear = Convert.ToUInt16(data[3])
                    });
                }
            }
            if (num_cases != inputCases.Count)
            {
                throw new Exception("There are some input cases with a incorrect format...");
            }
            Input inputmodel = new Input()
            {
                Total = num_cases,
                InputCases = inputCases
            };
            bindingContext.Result = ModelBindingResult.Success(inputmodel);
            return Task.CompletedTask;
        }
    }
}

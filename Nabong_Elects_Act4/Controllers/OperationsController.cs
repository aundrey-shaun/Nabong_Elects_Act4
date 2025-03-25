using Microsoft.AspNetCore.Mvc;
using System;

namespace Nabong_Elects_Act4.Controllers
{
    public class OperationsController : Controller
    {
        [HttpGet]
        public IActionResult ProcessOperation(string operation, double num1, double num2)
        {
            try
            {
                // Validate the operation
                switch (operation.ToLower())
                {
                    case "add":
                        return Content((num1 + num2).ToString());
                    case "subtract":
                        return Content((num1 - num2).ToString());
                    case "multiply":
                        return Content((num1 * num2).ToString());
                    case "divide":
                        // Handle division by zero
                        if (num2 == 0)
                        {
                            return Content("Error: Division by zero is not allowed");
                        }
                        return Content((num1 / num2).ToString());
                    default:
                        return Content($"Error: Invalid operation '{operation}'");
                }
            }
            catch (FormatException)
            {
                return Content("Error: Invalid numeric input");
            }
            catch (Exception ex)
            {
                return Content($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
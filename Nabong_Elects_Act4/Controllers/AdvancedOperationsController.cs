using Microsoft.AspNetCore.Mvc;

namespace Nabong_Elects_Act4.Controllers
{
    public class AdvancedOperationsController : Controller
    {
        [HttpGet]
        public IActionResult ProcessAdvancedOperation(string operation, double? num, double? exponent)
        {
            try
            {
                // Validate the operation
                switch (operation.ToLower())
                {
                    case "square":
                        if (!num.HasValue)
                        {
                            return Content("Error: Number is required for square operation");
                        }
                        return Content(Math.Pow(num.Value, 2).ToString());

                    case "squareroot":
                        if (!num.HasValue)
                        {
                            return Content("Error: Number is required for square root operation");
                        }
                        if (num.Value < 0)
                        {
                            return Content("Error: Cannot calculate square root of a negative number");
                        }
                        return Content(Math.Sqrt(num.Value).ToString());

                    case "power":
                        if (!num.HasValue || !exponent.HasValue)
                        {
                            return Content("Error: Base and exponent are required for power operation");
                        }
                        return Content(Math.Pow(num.Value, exponent.Value).ToString());

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

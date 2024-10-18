using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2_Fixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
       
        [HttpPost(template: "Cupcakes")]
        [Consumes("application/x-www-form-urlencoded")]

        public int Cupcakes([FromForm] int Smallboxes, [FromForm] int Bigboxes)

        {
            int totalcupcakes = (Smallboxes * 3) + (Bigboxes * 8);
            int leftover = totalcupcakes - 28;
            return leftover;
        }
    }
}
/// <summary>
/// Calculates the number of leftover cupcakes after distributing one cupcake to each student in the class.
/// A regular box of cupcakes holds 8 cupcakes, while a small box holds 3 cupcakes.
/// There are 28 students in a class and a total of at least 28 cupcakes. 
/// </summary>
/// <param name="Smallboxes">The number of small boxes (each containing 3 cupcakes).</param>
/// <param name="Bigboxes">The number of big boxes (each containing 8 cupcakes).</param>
/// <returns>
/// The number of cupcakes left over after each student receives one cupcake.
/// </returns>
/// <example>
/// GET : api/Cupcake/CalculateLeftover?Smallboxes=2&Bigboxes=5 -> 
/// Total cupcakes: 8 * 5 + 3 * 2 = 40 + 6 = 46
/// Leftover cupcakes: 46 - 28 = 18
/// </example>
/// <example>
/// GET : api/Cupcake/CalculateLeftover?Smallboxes=0&Bigboxes=4 -> 
/// Total cupcakes: 8 * 4 + 3 * 0 = 32 + 0 = 32
/// Leftover cupcakes: 32 - 28 = 4
/// </example>
/// <example>
/// GET : api/Cupcake/CalculateLeftover?Smallboxes=3&Bigboxes=0 -> 
/// Total cupcakes: 8 * 0 + 3 * 3 = 0 + 9 = 9
/// Leftover cupcakes: 9 - 28 = -19 (not enough cupcakes)
/// </example>
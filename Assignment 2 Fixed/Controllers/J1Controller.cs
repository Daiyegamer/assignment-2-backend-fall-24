using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2_Fixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the total score for a delivery robot based on the number of collisions and deliveries.
        /// </summary>
        /// <param name="Collisions">The number of collisions the robot experienced.</param>
        /// <param name="Deliveries">The number of successful deliveries made by the robot.</param>
        /// <returns>
        /// The total score calculated using the formula:
        /// Total Score = (Deliveries * 50) - (Collisions * 10) + Bonus,
        /// where Bonus is 500 if Deliveries > Collisions, otherwise 0.
        /// </returns>
        /// <example>
        /// POST : api/J1/delivedroid with body: 
        /// Collisions=3&Deliveries=10 -> 
        /// Total Score: (10 * 50) - (3 * 10) + 500 = 500 - 30 + 500 = 970
        /// </example>
        /// <example>
        /// POST : api/J1/delivedroid with body: 
        /// Collisions=5&Deliveries=5 -> 
        /// Total Score: (5 * 50) - (5 * 10) + 0 = 250 - 50 + 0 = 200
        /// </example>
        /// <example>
        /// POST : api/J1/delivedroid with body: 
        /// Collisions=2&Deliveries=7 -> 
        /// Total Score: (7 * 50) - (2 * 10) + 500 = 350 - 20 + 500 = 830
        /// </example>
        [HttpPost(template: "delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]

        public int delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            int bonus;
            if (Deliveries > Collisions) bonus = 500;
            else bonus = 0;

            int totalscore = (Deliveries * 50) - (Collisions * 10) + (bonus);
            return totalscore;
        }


    }
}
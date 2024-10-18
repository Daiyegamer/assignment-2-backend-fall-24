using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2_Fixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J5controller : ControllerBase
    {
        /// <summary>
        /// Processes a string of secret codes to determine directions and steps based on the codes provided.
        /// Each code consists of two digits representing the direction and a series of digits representing the steps.
        /// The direction is calculated by the sum of the first two digits of each code based on if the number is odd or even.
        /// </summary>
        /// <param name="secretcode">A  string of secret codes separated by a space where each code is at least 5 characters long.</param>
        /// <returns>
        /// A list of strings indicating the direction and the number of steps for each valid code.
        /// If the first code's first two digits are "00", an error response is returned.
        /// </returns>
        /// <example>
        /// GET : api/J5/Secretcode?secretcode=12345 67890 99999 -> 
        /// The first code is "12345":
        /// - Direction finder: 12, Steps: 345
        /// - Sum of digits: 1 + 2 = 3 (odd) → Direction: "left"
        /// Result: "left 345"
        /// 
        /// The second code is "67890":
        /// - Direction finder: 67, Steps: 890
        /// - Sum of digits: 6 + 7 = 13 (odd) → Direction: "left"
        /// Result: "left 890"
        /// 
        /// The third code is "99999":
        /// - Breaks the loop.
        /// 
        /// Final Output: ["left 345", "left 890"]
        /// </example>
        /// <example>
        /// GET : api/J5/Secretcode?secretcode=00001 23456 99999 -> 
        /// The first code is "00001":
        /// - Direction finder: 00 (not allowed) → Returns BadRequest: "The first two digits of the first code cannot be '00'.
        /// 
        /// Final Output: BadRequest
        /// </example>
        /// <example>
        /// GET : api/J5/Secretcode?secretcode=98765 12345 99999 -> 
        /// The first code is "98765":
        /// - Direction finder: 98, Steps: 765
        /// - Sum of digits: 9 + 8 = 17 (odd) → Direction: "left"
        /// Result: "left 765"
        /// 
        /// The second code is "12345":
        /// - Direction finder: 12, Steps: 345
        /// - Sum of digits: 1 + 2 = 3 (odd) → Direction: "left"
        /// Result: "left 345"
        /// 
        /// The third code is "99999":
        /// - Breaks the loop .
        /// 
        /// Final Output: ["left 765", "left 345"]
        /// </example>
        [HttpGet("Secretcode")]
        public ActionResult<List<string>> Secretcode(string secretcode)
        {
           

            var secretcodelist = secretcode.Split(" ").ToList();
            List<string> results = new List<string>();
            string lastDirection = null;

            
            if (secretcodelist.Count > 0 && secretcodelist[0].Length >= 2 && secretcodelist[0].Substring(0, 2) == "00")
            {
                return BadRequest("The first two digits of the first code cannot be '00'.");
            }

            foreach (var setofcodes in secretcodelist)
            {
                if (setofcodes == "99999")
                    break;

                string directionfinder = setofcodes.Substring(0, 2);
                string steps = setofcodes.Substring(2);

                int sumofdigits = (directionfinder[0] - '0') + (directionfinder[1] - '0');
                string direction;

                if (sumofdigits == 0)
                {
                    direction = lastDirection;
                }
                else if (sumofdigits % 2 == 1)
                {
                    direction = "left";
                }
                else
                {
                    direction = "right";
                }

                lastDirection = direction;

                results.Add($"{direction} {int.Parse(steps)}");
            }

            return Ok(results);
        }
    }
}
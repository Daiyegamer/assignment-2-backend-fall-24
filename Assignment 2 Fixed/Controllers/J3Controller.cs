using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2_Fixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase

    {
/// <summary> 
/// Calculates the total heat level based on the provided chilli ingredients.
/// Each ingredient name corresponds to a specific heat value in SHU.
/// The total heat level is the sum of the SHU values for all specified chilli types.
/// </summary>
/// <param name="Ingredients">A string of chilli pepper names separated by a comma.</param>
/// <returns>The total heat level as an integer, representing the total Heat Units of the specified ingredients.</returns>
/// <example>
/// GET api/J3/Chilliflakes?Ingredients=Poblano,Mirasol,Serrano -> 
/// The input includes:
/// - Poblano: 1500 SHU
/// - Mirasol: 6000 SHU
/// - Serrano: 15500 SHU
/// 
/// Calculation: 1500 + 6000 + 15500 = 23000
/// 
/// Final Output: 23000
/// </example>
/// <example>
/// GET api/J3/Chilliflakes?Ingredients=Cayenne,Habanero -> 
/// The input includes:
/// - Cayenne: 40000 SHU
/// - Habanero: 125000 SHU
/// 
/// Calculation: 40000 + 125000 = 165000
/// 
/// Final Output: 165000
/// </example>
/// <example>
/// GET api/J3/Chilliflakes?Ingredients=Thai -> 
/// The input includes:
/// - Thai: 75000 SHU
/// 
/// Final Output: 75000
/// </example>>
        [HttpGet(template:"Chilliflakes")]
        public int total(string Ingredients)
        {            
            List<string>list = Ingredients.Split(",").ToList();            
            int total = 0;
            for (int n = 0; n < list.Count; n = n + 1)
            {
                if (list[n] == "Poblano")
                {
                    total = total + 1500;
                }
                else if (list[n] == "Mirasol")
                {
                    total = total + 6000;
                }
                else if (list[n] == "Serrano")
                {
                    total = total + 15500;
                }
                else if (list[n] == "Cayenne")
                {
                    total = total + 40000;
                }
                else if (list[n] == "Thai")
                {
                    total = total + 75000;
                }
                else if (list[n] == "Habanero")
                {
                    total = total + 125000;
                }
                
            }
            return total;
        }
    }
}

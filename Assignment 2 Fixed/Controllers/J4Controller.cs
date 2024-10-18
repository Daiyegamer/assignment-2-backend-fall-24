using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Assignment_2_Fixed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J4Controller : ControllerBase
    {
        /// <summary>
        /// The SilentAuction method processes a string input representing bids 
        /// in a silent auction format. 
        /// It identifies the highest bid and the corresponding winner
        /// while ensuring that the bids meet certain criteria.
        /// </summary>
        /// <param name="input">(string input: A comma-separated string 
        /// where the first element is the number of bids 
        /// Subsequent elements alternate between bidder names
        /// and their corresponding bid amounts.</param>
        /// <returns>
        /// An error message if the highest bid exceeds 2000: "please enter a bid under 2000".
        /// An error message if the number of bids is 
        /// 0 or greater than 99: "please return at least one bid".
        /// The name of the winning bidder 
        /// if all demands are satisfied: "The winner is {winner}".
        /// </returns>
        /// <example>
        /// GET : api/Auction/SilentAuction?input=3,John,1500,Jane,1800,Mark,1200 -> 
        /// "The winner is Jane"
        /// </example>
        /// <example>
        /// GET : api/Auction/SilentAuction?input=2,Alice,2500,Bob,3000 -> 
        /// "please enter a bid under 2000"
        /// </example>
        /// <example>
        /// GET : api/Auction/SilentAuction?input=0 -> 
        /// "please return at least one bid"
        /// </example>
        /// <example>
        /// GET : api/Auction/SilentAuction?input=4,Charlie,1000,David,2000,Eve,1100,Frank,1300 -> 
        /// "The winner is David"
        /// </example>
        [HttpGet(template: "SilentAuction")]
        public string SilentAuction(string input)
        {
            List<string> auctionlist = input.Split(",").ToList();
            int numberofbids = int.Parse(auctionlist[0]);
            int highestbid = 0;
            string winner = "";
            int currentbid = 0;
            for (int i = 1; i < auctionlist.Count; i = i + 2)
            {
                currentbid = int.Parse(auctionlist[i + 1]);
                if (currentbid > highestbid)
                {
                    highestbid = currentbid;

                    winner = auctionlist[i];
                }
            }
            if (highestbid > 2000)
            {
                return "please enter a bid under 2000";
            }
            else if (numberofbids==0||numberofbids>99)
            {
                return "please return atleast one bid";
            }
              else return $"The winner is " + winner;
        }
    }
}




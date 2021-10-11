using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreApi_JWT.Controllers
{
    [ApiController]
    [Route("v1/home")]
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("evenorodd/{value:int}")]
        [AllowAnonymous]
        public ActionResult<dynamic> ValueIsEvenOrOdd(int value)
        {
            string evenorodd = "Odd";

            if (value % 2 == 0)
                evenorodd = "Even";

            return new
            {
                User = String.Format("Authenticated user - {0}", "Anonymous user"),
                Number = value,
                EvenOrOdd = evenorodd
            };
        }


        [HttpGet]
        [Route("isprime/{value:int}")]
        [Authorize("Bearer")]
        public ActionResult<dynamic> ValueIsPrime(int value)
        {
            bool isPrime = true;

            if (value <= 1) isPrime = false;
            if (value == 2) isPrime = true;
            if (value % 2 == 0) isPrime = false;

            var boundary = (int)Math.Floor(Math.Sqrt(value));

            for (int i = 3; i <= boundary; i += 2) {
                if (value % i == 0) {
                    isPrime = false;
                    break;
                }
            }

            return new
            {
                User = String.Format("Authenticated user - {0}", User.Identity.Name),
                Number = value,
                IsPrime = isPrime
            };
        }


    }
}

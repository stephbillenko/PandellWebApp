using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PandellWebApp.Controllers
{
    public class PandellController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateNumbers(int startNum, int endNum)
        {
            /*solution based mostly on code/logic from here: https://stackoverflow.com/questions/30014901/generating-random-numbers-without-repeating-c
            first started out with hashset because it guarantees uniqueness so we don't have to deal with duplicates 
            BUT... for the last few numbers your hoping the generator generates the right numbers, which could take a long time. 
            For the last number you have a 1 in 10,000 chance of hitting the last number you need.
            This made me realize we're not actually looking to generate random numbers. We're looking to randomly shuffle the numbers from 1 to 10,000.
            I used parameters instead of hardcoding the values just to make it a bit more generic so it can be used to shuffle any range of numbers. 
            However I did not give the user the ability to select the range because the requirements were specific with regard to the range.
            I chose a web app isntead of a console app because it's more user friendly. 
            I chose to add some styling because that's the first thing clients see - before they even know if it works or not.*/

            Random rand = new Random();
            List<int> possible = Enumerable.Range(startNum, endNum).ToList();
            List<int> listNumbers = new List<int>();
            while (possible.Count > 0)
            {
                int index = rand.Next(0, possible.Count);
                listNumbers.Add(possible[index]);
                possible.RemoveAt(index);
            }

            var finalList = string.Join(","+Environment.NewLine, listNumbers);
            ViewBag.generatedList = finalList;
            return View("Index");
        }
    }
}

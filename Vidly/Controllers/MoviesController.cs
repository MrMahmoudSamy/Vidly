using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            Movies Movie = new Movies() { Name = "Lost in Translate" };
            var customer = new List<Customer>
            {
                new Customer {CustomerName="Customer1" },
                new Customer {CustomerName="Customer2" }
            };
            var viewModels = new RandomMoviesViewModel
            {
                Movie = Movie,
                Customers = customer
            };
            return View(viewModels);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            var Movie = GetMovies();
            return View(Movie);
        }
        public ActionResult Details(int Id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var movie = GetMovies().SingleOrDefault(m => m.Id == Id);
            if(movie==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }
        private IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                 new Movies {Id=1,Name="AntMan" },
                new Movies {Id=2,Name="No country for oldman" }
            };
        }
    }
}
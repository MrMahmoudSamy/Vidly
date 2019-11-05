using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
       private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
            var Movie = _context.Movie.Include(m=>m.Genre).ToList();
            return View(Movie);
        }
        public ActionResult Details(int Id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var movie = _context.Movie.Include(m=>m.Genre).SingleOrDefault(m => m.Id == Id);
            if(movie==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }
       
    }
}
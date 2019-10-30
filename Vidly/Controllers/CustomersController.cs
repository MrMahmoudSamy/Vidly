using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customer = GetCustomer();
            return View(customer);
        }
        public ActionResult Details(int Id)
        {
            var customer = GetCustomer().SingleOrDefault(c => c.CustomerId == Id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomer()
        {
            return new List<Customer>
            {
                new Customer {CustomerId=1,CustomerName="Mahmoud Samy" },
                 new Customer {CustomerId=2,CustomerName="Mohamed Attia" }
            };
        }
    }
}
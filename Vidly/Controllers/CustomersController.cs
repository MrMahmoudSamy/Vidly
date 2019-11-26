using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //var customer = _context.Customers.Include(c=>c.MemberShipType).ToList();
            return View();
        }
        public ActionResult Details(int Id)
        {

            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.CustomerId == Id);
            if (customer == null)
                return HttpNotFound();
            
            return View(customer);
        }
        public ActionResult New()
        {
            var memberShiptype = _context.MemberShipTypes.ToList();
            var viewmodel = new CreateNewCustomer
            {
                Customers=new Customer(),
                MemberShipTypes = memberShiptype
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer Customers)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new CreateNewCustomer
                {
                    Customers = Customers,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("New", viewmodel);
            }
            if(Customers.CustomerId==0)
            {
                _context.Customers.Add(Customers);
            }
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.CustomerId == Customers.CustomerId);
                CustomerInDb.CustomerName = Customers.CustomerName;
                CustomerInDb.BirthDate = Customers.BirthDate;
                CustomerInDb.IsSubscribedToNewsLatter = Customers.IsSubscribedToNewsLatter;
                CustomerInDb.MemberShipTypeId = Customers.MemberShipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == Id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new CreateNewCustomer
            {
                Customers = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("New",viewmodel);
        }
       
    }
}
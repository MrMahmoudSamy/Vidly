﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
            var customer = _context.Customers.Include(c=>c.MemberShipType).ToList();
            return View(customer);
        }
        public ActionResult Details(int Id)
        {

            var customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(c => c.CustomerId == Id);
            if (customer == null)
                return HttpNotFound();
            
            return View(customer);
        }

       
    }
}
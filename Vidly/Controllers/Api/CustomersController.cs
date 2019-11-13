using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get/api/customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        //Get/api/customer/1
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }
        //Post/api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        //Put/api/customer/1
        [HttpPut]
        public void UpdateCustomer (int id ,Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb=_context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.CustomerName = customer.CustomerName;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsLatter = customer.IsSubscribedToNewsLatter;
            customerInDb.MemberShipTypeId = customer.MemberShipTypeId;

            _context.SaveChanges();
        }

        //delete/api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Dtos;
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
        public IHttpActionResult GetCustomers()
        {
            var customer= _context.Customers
                .Include(c=>c.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customer);
        }
        //Get/api/customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return NotFound();

            return Ok (Mapper.Map<Customer,CustomerDto>(customer));
        }
        //Post/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.CustomerId = customer.CustomerId;

            return Created(new Uri(Request.RequestUri+"/"+customer.CustomerId),customerDto);
        }
        //Put/api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer (int id ,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb=_context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto,customerInDb);
            //customerInDb.CustomerName = customer.CustomerName;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribedToNewsLatter = customer.IsSubscribedToNewsLatter;
            //customerInDb.MemberShipTypeId = customer.MemberShipTypeId;

            _context.SaveChanges();
            return Ok();
        }

        //delete/api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}

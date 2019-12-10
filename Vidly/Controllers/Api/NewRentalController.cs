using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        //public IHttpActionResult GetMovieById(int id)
        //{
        //    Movies MovieById = null;

        //    using (var context = new ApplicationDbContext())
        //    {
        //        MovieById = context.Movie.SingleOrDefault(m => m.Id == id);
        //    }
        //    if (MovieById == null)
        //        return NotFound();
        //    return Ok(Mapper.Map<Movies, MovieDto>(MovieById));
        //}

        //public IHttpActionResult GetCustomerById(int id)
        //{
        //    Customer Customer = null;
        //    using (var context = new ApplicationDbContext())
        //    {
        //        Customer = context.Customers.SingleOrDefault(c => c.CustomerId == id);
        //        if (Customer == null)
        //            return NotFound();
        //        return Ok(Mapper.Map<Customer, CustomerDto>(Customer));
        //    }
        //}

            [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto NewRental)
        {
           
            
            using (var context = new ApplicationDbContext())
            {
               var customer = context.Customers.SingleOrDefault(c => c.CustomerId == NewRental.CustomerId);
               var movies = context.Movie.Where(m => NewRental.MovieIds.Contains(m.Id));
                foreach (var movie in movies)
                {
                    var rental = new NewRental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRental = DateTime.Now

                    };
                    context.Rentals.Add(rental);
                }
                context.SaveChanges();
            }
            return Ok();
        }
    }
}

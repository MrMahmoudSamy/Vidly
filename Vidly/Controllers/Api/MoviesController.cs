using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetMovies(string query=null)
        {
            
           
               var Moviequery = _context.Movie
                   .Include(m => m.Genre);

                if(!StringHelper.IsNullOrWhiteSpace(query))
                {
                Moviequery = Moviequery.Where(m => m.Name.Contains(query));
                }
                var Moviedto=Moviequery
                    .ToList()
                    .Select(Mapper.Map<Movies, MovieDto>);
                
            

            return Ok(Moviedto);
        }
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            Movies MovieById = null;

            using (var context = new ApplicationDbContext())
            {
                MovieById = context.Movie.SingleOrDefault(m => m.Id == id);
            }
            if (MovieById == null)
                return NotFound();
            return Ok(Mapper.Map<Movies, MovieDto>(MovieById));
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movies>(movieDto);
            using (var context = new ApplicationDbContext())
            {
                context.Movie.Add(movie);
                context.SaveChanges();
            }
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Movies MovieInDb = null;
            using (var context = new ApplicationDbContext())
            {
                MovieInDb = context.Movie.SingleOrDefault(m => m.Id == id);
                if (MovieInDb == null)
                    return NotFound();
                Mapper.Map(movieDto, MovieInDb);
                context.SaveChanges();
            }
            return Ok();
        }
        public IHttpActionResult DeleteMovie(int id)
        {
            Movies MovieInDb = null;
            using (var context = new ApplicationDbContext())
            {
                MovieInDb = context.Movie.SingleOrDefault(m => m.Id == id);
                if (MovieInDb == null)
                    return NotFound();
                context.Movie.Remove(MovieInDb);
                context.SaveChanges();
            }
            return Ok();
        }
    }
}

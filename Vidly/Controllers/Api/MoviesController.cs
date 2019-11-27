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
        public MoviesController()
        {

        }

        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            IEnumerable<MovieDto> AllMovies = null;
            using (var context = new ApplicationDbContext())
            {
                 AllMovies = context.Movie
                    .Include(m=>m.Genre)
                    .ToList()
                    .Select(Mapper.Map<Movies, MovieDto>);
                
            }

            return Ok(AllMovies);
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

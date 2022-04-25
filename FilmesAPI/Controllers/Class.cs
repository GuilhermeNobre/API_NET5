using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController: ControllerBase
    {
        private MovieContext _movieContext;
        private IMapper _mapper; 

        public MovieController(MovieContext context, IMapper AutoMapper)
        {
            _movieContext = context;
            _mapper = AutoMapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDTO movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return CreatedAtAction(nameof(ReturnMovieByID), new { Id = movie.Id }, movie);
            //Console.WriteLine(movie.Title);
        }

        [HttpGet]
        public IEnumerable<Movie> RecuseMovie()
        {
            
            return _movieContext.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult ReturnMovieByID(int id)
        {
            Movie movie = _movieContext.Movies.FirstOrDefault(movies => movies.Id == id);
            if (movie != null) 
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movieDto); 
            }
            
            return NotFound(); 

            //return movies.FirstOrDefault(movies => movies.Id == id);


            /* Versão de código sem funções C#
            foreach(Movie movie in movies)
            {
                if(movie.Id == id) return movie;
            }
            return null;
            */
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movieToChange = _movieContext.Movies.FirstOrDefault(Movie => Movie.Id == id);
            if(movieToChange == null)
            {
                return NotFound();
            }

            movieToChange.Title = movieDto.Title;
            movieToChange.Director = movieDto.Director;
            movieToChange.Gender = movieDto.Gender;
            movieToChange.Duracao = movieDto.Duracao;
            _movieContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletMovie(int id)
        {
            Movie movieToDelete = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movieToDelete != null)
            {
                _movieContext.Remove(movieToDelete);
                _movieContext.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}

using AutoMapper;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<Movie, ReadMovieDto>();
            CreateMap<UpdateMovieDTO, Movie>(); 
        }
    }
}

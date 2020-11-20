using Movie.Application.Dtos;
using Movie.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Movie.Domain.Interfaces;
using System.Linq;

namespace Movie.Application.Services
{
    public class MoviesService : IMoviesService
    {

        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
       

        public MoviesDto GetMovieById(int id)
        {
            var movie = _moviesRepository.GetMovieById(id).FirstOrDefault();

            var movieDto = new MoviesDto()
            {
                codigo_filme = movie.Id,
                nome_filme = movie.Title,
                nota = movie.Rank
            };
            return movieDto;
        }

        public IEnumerable<MoviesDto> GetMovies()
        {
            List<MoviesDto> moviesDtos = new List<MoviesDto>();

            var movie = _moviesRepository.GetMovies();

            foreach (var mo in movie)
            {
                moviesDtos.Add(new MoviesDto()
                {
                    codigo_filme = mo.Id,
                    nome_filme = mo.Title,
                    nota = mo.Rank
                });
            }
            return moviesDtos;

        }
    }
}

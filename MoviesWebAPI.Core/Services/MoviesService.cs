using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Repositories.Interfaces;
using MoviesWebAPI.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Core.Services
{
    public class MoviesService:IMoviesService
    {
        private IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            return await _moviesRepository.GetMovieById(movieId);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _moviesRepository.GetMovies();
        }
    }
}

using MoviesWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Core.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int movieId);
    }
}

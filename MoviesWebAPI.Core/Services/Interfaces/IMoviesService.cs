using MoviesWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Core.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int movieId);
    }
}

using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Core.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetMovies()
        {
            throw new NotImplementedException();
        }
    }
}

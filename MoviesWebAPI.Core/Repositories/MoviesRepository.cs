using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebAPI.Core.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var json = System.IO.File.ReadAllText("movies.json");

            var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
            return  movies;
        }
    }
}

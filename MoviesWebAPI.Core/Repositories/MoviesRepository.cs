using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MoviesWebAPI.Core.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            using(StreamReader reader = new StreamReader("movies.json"))
            {
                var json = reader.ReadToEnd();
                var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
                return movies;
            }
        }
        public async Task<Movie> GetMovieById(int movieId)
        {
            var movies = await GetMovies();
            var movieDetails = movies.FirstOrDefault(x => x.MovieId == movieId);
            return movieDetails;
        }

    }
}

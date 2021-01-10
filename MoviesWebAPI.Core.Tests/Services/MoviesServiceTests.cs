using Moq;
using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Repositories.Interfaces;
using MoviesWebAPI.Core.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWebAPI.Core.Tests.Services
{
    public class MoviesServiceTests
    {
        private MoviesService _moviesService;
        private Mock<IMoviesRepository> _mockMoviesRepository;
        List<Movie> _movies;
        Movie _movieDetails;
        int _movieId = 1;
        [SetUp]
        public void Setup()
        {
            _mockMoviesRepository = new Mock<IMoviesRepository>();
            _moviesService = new MoviesService(_mockMoviesRepository.Object);
            _movies = new List<Movie>() 
            { 
                new Movie(),
                new Movie()
            };
            _movieDetails = new Movie()
            {
                MovieId = _movieId
            };
        }

        [Test]
        public async Task GetMoviesAsync_ReturnsMoviesFromRepository()
        {
            _mockMoviesRepository.Setup(x => x.GetMovies()).ReturnsAsync(_movies);

            var result = await _moviesService.GetMoviesAsync();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetMovieByIdAsync_ReturnsMovieDetailsFromRepository()
        {
            _mockMoviesRepository.Setup(x => x.GetMovieById(_movieId)).ReturnsAsync(_movieDetails);

            var result = await _moviesService.GetMovieByIdAsync(_movieId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.MovieId, Is.EqualTo(_movieId));
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesWebAPI.Controllers;
using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Services.Interfaces;
using MoviesWebAPI.Dto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MoviesWebAPI.Tests.Controllers
{
    public class MoviesControllerTests
    {
        private MoviesController _moviesController;
        private Mock<IMoviesService> _mockMoviesService;
        private Mock<IMapper> _mockMapper;
        private List<Movie> _movies;
        private List<MovieDto> _movieDtos;
        private Movie _movieDetails;
        private MovieDto _movieDetailsDto;
        private int? _movieId = 1;
        private const string GetMoviesAsync = "GetMoviesAsync";
        private const string GetMovieByIdAsync = "GetMovieByIdAsync";
        private const string GetMyBookedMoviesAsync = "GetMyBookedMoviesAsync";

        [SetUp]
        public void Setup()
        {
            _mockMoviesService = new Mock<IMoviesService>();
            _mockMapper = new Mock<IMapper>();
            _movies = new List<Movie>();
            _movieDtos = new List<MovieDto>();
            _movieDetails = new Movie();
            _movieDetailsDto = new MovieDto();
            _moviesController = new MoviesController(_mockMoviesService.Object, _mockMapper.Object);

        }

        [Test]
        public void GetMoviesAsync_HasGetAttribute()
        {
            var method = typeof(MoviesController).GetMethod(GetMoviesAsync);

            var attribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), false).Cast<HttpGetAttribute>().FirstOrDefault();

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public async Task GetMoviesAsync_ReturnsOkResultWithMoviesDto()
        {
            //arrange
            _mockMoviesService.Setup(x => x.GetMoviesAsync()).ReturnsAsync(_movies);
            _mockMapper.Setup(x => x.Map<IEnumerable<MovieDto>>(_movies)).Returns(_movieDtos);

            //act
            var response = await _moviesController.GetMoviesAsync();

            //assert
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var result = response as OkObjectResult;
            Assert.That(result.Value, Is.TypeOf<List<MovieDto>>());
        }
        [Test]
        public async Task GetMoviesAsync_IfMoviesServiceCallThrowsException_ReturnsBadRequest()
        {
            _mockMoviesService.Setup(x => x.GetMoviesAsync()).ThrowsAsync(new Exception());

            var response = await _moviesController.GetMoviesAsync();

            Assert.That(response, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public void GetMovieByIdAsync_HasGetAttribute()
        {
            var method = typeof(MoviesController).GetMethod(GetMovieByIdAsync);

            var attribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), false).Cast<HttpGetAttribute>().FirstOrDefault();

            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute.Template, Is.EqualTo("movieDetails"));
        }

        [Test]
        public async Task GetMovieByIdAsync_IfMovieIdNull_ReturnsBadRequest()
        {
            var response = await _moviesController.GetMovieByIdAsync(null);

            Assert.That(response, Is.TypeOf<BadRequestObjectResult>());
        }
        [Test]
        public async Task GetMovieByIdAsync_IfMovieNotFound_ReturnsBadRequest()
        {
            Movie movie = null;
            _mockMoviesService.Setup(x => x.GetMovieByIdAsync(_movieId.Value)).ReturnsAsync(movie);

            var response = await _moviesController.GetMovieByIdAsync(_movieId);

            Assert.That(response, Is.TypeOf<BadRequestObjectResult>());
        }
        [Test]
        public async Task GetMovieByIdAsync_IfMovieIdValid_ReturnsOKObjectResultWithMovieDto()
        {
            _mockMoviesService.Setup(x => x.GetMovieByIdAsync(_movieId.Value)).ReturnsAsync(_movieDetails);
            _mockMapper.Setup(x => x.Map<MovieDto>(_movieDetails)).Returns(_movieDetailsDto);

            var response = await _moviesController.GetMovieByIdAsync(_movieId);

            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var result = response as OkObjectResult;
            Assert.That(result.Value, Is.TypeOf<MovieDto>());
        }

        [Test]
        public async Task GetMovieByIdAsync_IfMoviesServiceCallThrowsException_ReturnsBadRequest()
        {
            _mockMoviesService.Setup(x => x.GetMovieByIdAsync(_movieId.Value)).ThrowsAsync(new Exception());

            var response = await _moviesController.GetMovieByIdAsync(_movieId);

            Assert.That(response, Is.TypeOf<BadRequestObjectResult>());
        }
        [Test]
        public void GetMyBookedMoviesAsync_HasGetAttribute()
        {
            var method = typeof(MoviesController).GetMethod(GetMoviesAsync);

            var attribute = method?.GetCustomAttributes(typeof(HttpGetAttribute), false).Cast<HttpGetAttribute>().FirstOrDefault();

            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute.Template, Is.EqualTo("myMovies"));
        }

        [Test]
        public async Task GetMyBookedMoviesAsync_ReturnsOkResultWithMoviesDto()
        {
            //arrange
            _mockMoviesService.Setup(x => x.GetMoviesAsync()).ReturnsAsync(_movies);
            _mockMapper.Setup(x => x.Map<IEnumerable<MovieDto>>(_movies)).Returns(_movieDtos);

            //act
            var response = await _moviesController.GetMoviesAsync();

            //assert
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var result = response as OkObjectResult;
            Assert.That(result.Value, Is.TypeOf<List<MovieDto>>());
        }
        [Test]
        public async Task GetMyBookedMoviesAsync_IfMoviesServiceCallThrowsException_ReturnsBadRequest()
        {
            _mockMoviesService.Setup(x => x.GetMoviesAsync()).ThrowsAsync(new Exception());

            var response = await _moviesController.GetMoviesAsync();

            Assert.That(response, Is.TypeOf<BadRequestObjectResult>());
        }
    }
}

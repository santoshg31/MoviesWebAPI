using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesWebAPI.Controllers;
using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Services.Interfaces;
using MoviesWebAPI.Dto;
using NUnit.Framework;
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
        private const string GetMoviesAsync = "GetMoviesAsync";

        [SetUp]
        public void Setup()
        {
            _mockMoviesService = new Mock<IMoviesService>();
            _mockMapper = new Mock<IMapper>();
            _movies = new List<Movie>();
            _movieDtos = new List<MovieDto>();
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
    }
}

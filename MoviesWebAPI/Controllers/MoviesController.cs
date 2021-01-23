using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Core.Services.Interfaces;
using MoviesWebAPI.Dto;

namespace MoviesWebAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private IMoviesService _moviesService;
        private IMapper _mapper;

        public MoviesController(IMoviesService moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetMoviesAsync()
        {
            try
            {
                var movies = await _moviesService.GetMoviesAsync();
                var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
                return Ok(moviesDto);
            }
            catch(Exception ex)
            {
                return BadRequest("Sorry something went wrong.");
            }
        }
        [HttpGet("movieDetails")]
        public async Task<IActionResult> GetMovieByIdAsync(int? movieId)
        {
            try
            {
                if (movieId == null)
                {
                    return BadRequest("Invalid movieId");
                }
                var movieDetails = await _moviesService.GetMovieByIdAsync(movieId.Value);
                if (movieDetails == null)
                {
                    return BadRequest("Movie not found");
                }
                var movieDetailsDto = _mapper.Map<MovieDto>(movieDetails);
                return Ok(movieDetailsDto);
            }
            catch(Exception ex)
            {
                return BadRequest("Sorry something went wrong.");
            }
            
        }

    }
}
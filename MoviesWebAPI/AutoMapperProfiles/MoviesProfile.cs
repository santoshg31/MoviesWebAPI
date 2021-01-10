using AutoMapper;
using MoviesWebAPI.Core.Models;
using MoviesWebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebAPI.AutoMapperProfiles
{
    public class MoviesProfile:Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
        }

    }
}

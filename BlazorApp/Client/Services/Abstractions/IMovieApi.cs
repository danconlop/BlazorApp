using BlazorApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Abstractions
{
    public interface IMovieApi
    {
        Task<string> Add(MovieDto model);
        Task<List<MovieDto>> GetAll();
    }
}

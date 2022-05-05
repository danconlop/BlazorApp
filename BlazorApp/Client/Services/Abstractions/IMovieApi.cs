using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Abstractions
{
    public interface IMovieApi
    {
        List<Movie> GetMovies();
    }
}

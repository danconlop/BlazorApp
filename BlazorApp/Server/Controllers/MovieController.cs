using BlazorApp.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext context;

        public MovieController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("all")]
        public async Task<List<MovieDto>> GetAll()
        {
            return await context.Movies.Include(a => a.Actors).Include(g => g.Genres).Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Poster = m.Poster,
                ReleaseDate = m.ReleaseDate,
                Actors = m.Actors.Select(a => new ActorDto()).ToList(),
                Genres = m.Genres.Select(g => new GenreDto()).ToList()
            }).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieDto model)
        {
            try
            {
                var movie = new Movie
                {
                    Title = model.Title,
                    ReleaseDate = model.ReleaseDate,
                    Poster = model.Poster,
                    Actors = model.Actors.Select(a => new Actor()).ToList(),
                    Genres = model.Genres.Select(g => new Genre(g.Name)).ToList()
                };

                await context.Movies.AddAsync(movie);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

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
    public class ActorController : ControllerBase
    {
        private readonly AppDbContext context;

        public ActorController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorDto model)
        {
            try
            {
                var actor = new Actor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    YearsActive = model.YearsActive,
                    PhotoUrl = model.PhotoUrl,
                    Bio = model.Bio
                };

                await context.Actors.AddAsync(actor);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("all")]
        public async Task<List<ActorDto>> GetAll()
        {
            return await context.Actors.Select(a => new ActorDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                YearsActive = a.YearsActive,
                PhotoUrl = a.PhotoUrl,
                Bio = a.Bio
            }).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActorDto> GetById(int id)
        {
            return await context.Actors.Select(a => new ActorDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                YearsActive = a.YearsActive,
                PhotoUrl = a.PhotoUrl,
                Bio = a.Bio
            }).FirstOrDefaultAsync(a => a.Id.Equals(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ActorDto model)
        {
            try
            {
                var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id.Equals(model.Id));
                if (actor is null)
                    throw new Exception("Element not found");

                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.DateOfBirth = model.DateOfBirth;
                actor.YearsActive = model.YearsActive;
                actor.PhotoUrl = model.PhotoUrl;
                actor.Bio = model.Bio;

                await context.SaveChangesAsync();
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

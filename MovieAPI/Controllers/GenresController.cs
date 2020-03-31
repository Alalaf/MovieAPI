using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DTOs;
using MovieAPI.Helpers;
using MovieAPI.Models;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await _db.Genres.ToListAsync();
            var genresDTOs = _mapper.Map<List<GenreDTO>>(genres);
            return genresDTOs;
        }


        [HttpGet("{Id:int}", Name ="GetGenre")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(g => g.Id == Id);
            if(genre == null)
            {
                return NotFound();
            }
            var genredto = _mapper.Map<GenreDTO>(genre);
            return genredto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]GenreCreationDTO GenreCreation)
        {
            var genre = _mapper.Map<Genre>(GenreCreation);
            _db.Add(genre);
           await _db.SaveChangesAsync();
            var genredto = _mapper.Map<GenreDTO>(genre);
            return new CreatedAtRouteResult("GetGenre",new { Id = genredto.Id},genredto);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id,[FromBody]GenreCreationDTO GenreEdit)
        {
            var genre = _mapper.Map<Genre>(GenreEdit);
            genre.Id = Id;
            _db.Entry(genre).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(g => g.Id == Id);
            if (genre == null)
            {
                return NotFound();
            }
             _db.Genres.Remove(genre);
            await _db.SaveChangesAsync();

            return NoContent();
        }


    }
}
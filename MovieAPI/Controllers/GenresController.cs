using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public GenresController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {

            return await _db.Genres.ToListAsync();
        }


        [HttpGet("{Id:int}", Name ="GetGenre")]
        public async Task<ActionResult<Genre>> Get(int Id)
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(g => g.Id == Id);
            if(genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Genre genre)
        {
            _db.Add(genre);
           await _db.SaveChangesAsync();
            return new CreatedAtRouteResult("GetGenre",new { Id = genre.Id},genre);
        }

        [HttpPut]
        public ActionResult Put([FromBody]Genre genre)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]Genre genre)
        {
            return NoContent();
        }


    }
}
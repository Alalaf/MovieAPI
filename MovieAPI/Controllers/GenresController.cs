using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IRepositoryGenre _repo;
        public GenresController(IRepositoryGenre repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Genre>> Get()
        {

            return _repo.GetAllGenres();
        }


        [HttpGet("{Id:int}", Name ="GetGenre")]
        public ActionResult<Genre> Get(int Id)
        {           
            var genre = _repo.GetGenre(Id);
            if(genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Genre genre)
        {
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
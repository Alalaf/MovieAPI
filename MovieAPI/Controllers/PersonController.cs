using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DTOs;
using MovieAPI.Helpers;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PersonController(ApplicationDbContext db,IMapper mapper)
        {
             _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get()
        {
            var Person = await _db.Person.ToListAsync();
            var persondto = _mapper.Map<List<PersonDTO>>(Person);
            return persondto;
        }

        [HttpGet("{Id:int}",Name ="GetPerson")]
        public async Task<ActionResult<PersonDTO>> Get(int Id)
        {
            var Person = await _db.Person.FirstOrDefaultAsync(p => p.Id == Id);
            var persondto = _mapper.Map<PersonDTO>(Person);
            return persondto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm]PersonCreationDTO personCreation)
        {
            var person = _mapper.Map<Person>(personCreation);
             _db.Add(person);
            await _db.SaveChangesAsync();
            var persondto = _mapper.Map<PersonDTO>(person);
            return new CreatedAtRouteResult("GetPerson", new { Id = person.Id }, persondto);
        }
    }
}
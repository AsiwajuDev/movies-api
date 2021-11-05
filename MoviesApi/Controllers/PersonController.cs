using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<PersonDTO>>> Get()
        {
            var response = await _dbContext.People.AsNoTracking().ToListAsync();
            var people = _mapper.Map<List<PersonDTO>>(response);
            return people;
        }

        [HttpGet("{Id:int}", Name = "getPersonById")]
        public async Task<ActionResult<PersonDTO>> Get(int Id)
        {
            var response = await _dbContext.People.FirstOrDefaultAsync(x => x.Id == Id);
            if (response == null)
            {
                return NotFound();
            }
            var person = _mapper.Map<PersonDTO>(response);

            return person;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonCreateDTO personCreate)
        {
            var person = _mapper.Map<Person>(personCreate);
            //_repository.AddGenre(genre);
            _dbContext.Add(person);
            await _dbContext.SaveChangesAsync();
            var personResponse = _mapper.Map<PersonDTO>(person);

            return new CreatedAtRouteResult("getPersonById", new { Id = personResponse.Id }, personResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonCreateDTO personCreate)
        {
            var person = _mapper.Map<Person>(personCreate);
            person.Id = id;
            _dbContext.Entry(person).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _dbContext.People.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.Remove(new Person () { Id = id });

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}

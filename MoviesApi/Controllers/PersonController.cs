using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTOs;
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

        public PersonController(ApplicationDbContext _dbContext, IMapper mapper)
        {
            _dbContext = _dbContext;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<PersonDTO>>> Get()
        {
            var response = await _dbContext.People.AsNoTracking().ToListAsync();
            var people = _mapper.Map<List<PersonDTO>>(response);
            return people;
        }
        
    }
}

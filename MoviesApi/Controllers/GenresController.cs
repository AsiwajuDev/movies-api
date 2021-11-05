using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using MoviesApi.Filters;
using MoviesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {        
        private readonly ILogger<GenresController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GenresController(ILogger<GenresController> logger, ApplicationDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var response = await _dbContext.Genres.AsNoTracking().ToListAsync();
            var genres = _mapper.Map<List<GenreDTO>>(response);
            return genres;
        }

        [HttpGet("{Id:int}", Name = "getGenreById")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var response = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == Id);
            if (response == null)
            {
                return NotFound();
            }
            var genre = _mapper.Map<GenreDTO>(response);

            return genre;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreateDTO genreCreate)
        {
            var genre = _mapper.Map<Genre>(genreCreate);
            //_repository.AddGenre(genre);
            _dbContext.Add(genre);
            await _dbContext.SaveChangesAsync();
            var genreResponse = _mapper.Map<GenreDTO>(genre);
             
            return new CreatedAtRouteResult("getGenreById", new { Id = genreResponse.Id }, genreResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreateDTO genreCreate)
        {
            var genre = _mapper.Map<Genre>(genreCreate);
            genre.Id = id;
            _dbContext.Entry(genre).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _dbContext.Genres.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
          
            _dbContext.Remove(new Genre() { Id = id });

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

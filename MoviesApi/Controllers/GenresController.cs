using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IRepository _repository;
        private readonly ILogger<GenresController> _logger;
        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            var genres = await _repository.GetAllGenres();
            return genres;
        }

        [HttpGet("{Id:int}", Name = "getGenreById")]
        public ActionResult<Genre> Get(int Id)
        {
            var genre = _repository.GetGenreById(Id);
            if(genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            _repository.AddGenre(genre);
            return new CreatedAtRouteResult("getGenreById", new { Id = genre.Id }, genre);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}

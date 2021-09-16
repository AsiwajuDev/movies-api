using Microsoft.AspNetCore.Mvc;
using MoviesApi.Entities;
using MoviesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : Controller
    {        
        private readonly IRepository _repository;
        public GenreController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public List<Genre> Get()
        {
            var genres = _repository.GetAllGenres();
            return genres;
        }

        [HttpPost]
        public void Post()
        {

        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}

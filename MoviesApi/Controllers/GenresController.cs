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
    public class GenresController : Controller
    {        
        private readonly IRepository _repository;
        public GenresController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public List<Genre> Get()
        {
            var genres = _repository.GetAllGenres();
            return genres;
        }

        [HttpGet]
        public Genre Get(int Id)
        {
            var genre = _repository.GetGenreById(Id);
            if(genre == null)
            {
                //return NotFound();
            }

            return genre;
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

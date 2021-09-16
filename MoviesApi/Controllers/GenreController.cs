using Microsoft.AspNetCore.Mvc;
using MoviesApi.Entities;
using MoviesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    public class GenreController : Controller
    {
        private readonly IRepository _repository;
        public GenreController(IRepository repository)
        {
            _repository = repository;
        }

        public List<Genre> Genres()
        {
            List<Genre> genres = new List<Genre>();
            return genres;
        }
    }
}

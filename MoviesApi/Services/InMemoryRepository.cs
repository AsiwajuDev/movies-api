﻿using MoviesApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genres;

        public InMemoryRepository() 
        {
            _genres = new List<Genre>()
            {
                new Genre(){Id = 1, Name = "Comedy"},
                new Genre(){Id = 2, Name = "Action"},
                new Genre(){Id = 3, Name = "Thriller"}
            };            
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(1);
            return _genres;
        }

        public Genre GetGenreById(int Id)
        {
            var obj = _genres.FirstOrDefault(x => x.Id == Id);
            return obj;
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = _genres.Max(x => x.Id) + 1;
            _genres.Add(genre);
        }
    }
}

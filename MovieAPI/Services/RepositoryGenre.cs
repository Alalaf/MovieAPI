using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class RepositoryGenre: IRepositoryGenre
    {
        private List<Genre> _genres;
        public RepositoryGenre()
        {
            _genres = new List<Genre>()
            {
                new Genre(){Id=1,Name="Comedy"},
                 new Genre(){Id=2,Name="Action"}
            };
        }

        public List<Genre> GetAllGenres()
        {
            return _genres;
        }

        public Genre GetGenre(int Id)
        {
            return _genres.FirstOrDefault(g => g.Id == Id);
        }
    }
}
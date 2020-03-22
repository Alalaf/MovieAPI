using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public interface IRepositoryGenre
    {
        List<Genre> GetAllGenres();
        Genre GetGenre(int Id);
    }
}

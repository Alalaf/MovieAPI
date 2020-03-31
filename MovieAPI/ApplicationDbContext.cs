using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext([NotNullAttribute]DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}

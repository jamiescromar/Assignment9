using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class MovieDbContext: DbContext
    {
        //This is the constructor for the Db context
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        //This is setting the table Movies into the Database
        public DbSet<Movie> Movies { get; set; }
    }
}

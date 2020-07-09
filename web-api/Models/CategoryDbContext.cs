using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace web_api.Models
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { set; get; }
    }
}

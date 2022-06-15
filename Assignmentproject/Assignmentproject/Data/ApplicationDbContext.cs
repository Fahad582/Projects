using Assignmentproject.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignmentproject.Data
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
    }
}

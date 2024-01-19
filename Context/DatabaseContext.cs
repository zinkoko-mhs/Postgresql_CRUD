using Microsoft.EntityFrameworkCore;
using PostgreSQL_CRUD.Models;

namespace PostgreSQL_CRUD.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Student> Student { get; set; }
    }
}
    
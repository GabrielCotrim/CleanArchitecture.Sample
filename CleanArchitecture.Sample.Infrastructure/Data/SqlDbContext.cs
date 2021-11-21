using CleanArchitecture.Sample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Sample.Infrastructure.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}

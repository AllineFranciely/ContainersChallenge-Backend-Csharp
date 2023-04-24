using ContainersChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace ContainersChallenge.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Container>? Containers { get; set; }

        public DbSet<Movimentacao>? Movimentacoes { get; set; }
    }
}

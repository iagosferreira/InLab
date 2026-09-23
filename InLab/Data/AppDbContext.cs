using Microsoft.EntityFrameworkCore;
using InLab.Models;

namespace InLab.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Detector> Detectores { get; set; }
        public DbSet<Calibracao> Calibracoes { get; set; }
    }
}
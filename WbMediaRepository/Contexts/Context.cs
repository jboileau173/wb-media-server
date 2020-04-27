using Microsoft.EntityFrameworkCore;
using WbMediaCore.Configurations.Interfaces;
using WbMediaModels;
using WbMediaRepository.ModelConfigurations;

namespace WbMediaRepository.Contexts
{
    public class Context : DbContext
    {
        public DbSet<File> Files { get; set; }

        private IDatabaseOptions _databaseOptions { get; set; }

        public Context(IDatabaseOptions databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql($"Server={_databaseOptions.Server};Database={_databaseOptions.Database};User Id={_databaseOptions.UserId};Password={_databaseOptions.Password};");
        }
    }
}

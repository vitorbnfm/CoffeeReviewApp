using CoffeeReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<CoffeeCategory> CoffeeCategories { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CoffeeCategory>()
                .HasKey(cc => new {cc.CoffeeId, cc.CategoryId});
            modelBuilder.Entity<CoffeeCategory>()
                .HasOne(c => c.Coffee)
                .WithMany(cc => cc.CoffeeCategories)
                .HasForeignKey(c => c.CoffeeId);
            modelBuilder.Entity<CoffeeCategory>()
                .HasOne(c => c.Category)
                .WithMany(cc => cc.CoffeeCategories)
                .HasForeignKey(c => c.CategoryId);


            
        }
        
    }
}
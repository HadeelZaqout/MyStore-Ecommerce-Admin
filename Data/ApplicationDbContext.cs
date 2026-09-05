using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStore.Data.Configurations;
using MyStore.Models;
using MyStore.Pages.Models;

namespace MyStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("tblUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("tblRoles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("tblUserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("tblUserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("tblUserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("tblRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("tblUserTokens");
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.Entity<IdentityUser>().HasData(new List<IdentityUser>() {
            //  new IdentityUser{ UserName="Hadeel" , Email="hadeel@gmail.com" }
            //});
        }

        
    }
}

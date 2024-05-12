using Entitiyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.EFCore.Config;
using System.Reflection;
namespace Repository.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options):base(options) { }
       
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Room> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Room>().HasKey(u => u.Id);
            modelBuilder.Entity<Meeting>().HasKey(u => u.Id);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(uc => uc.Id);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasKey(rc => rc.Id);
        }
    }
}

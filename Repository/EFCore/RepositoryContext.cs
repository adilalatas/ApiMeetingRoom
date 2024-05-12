using Entitiyes.Models;
using Microsoft.EntityFrameworkCore;
using Repository.EFCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options) { }
       
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}

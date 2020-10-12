using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngASPNETCOREBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AngASPNETCOREBackend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversations>()
                        .HasOne(c => c.Reciever)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Conversations>()
                       .HasOne(c => c.Sender)
                       .WithMany()
                       .OnDelete(DeleteBehavior.NoAction);

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Conversations> Conversations { get; set; }
    }
}

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

        public DbSet<Users> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApp.DAL.Entities
{
    public class PresentationContext : DbContext
    {
        public PresentationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}

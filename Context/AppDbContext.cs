﻿using AuthentificationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthentificationApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}

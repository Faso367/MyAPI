﻿using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

namespace MyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }//Database.EnsureCreated(); } // НЕ ЗАБЫТЬ ЗАКОММЕНТИТЬ
        public DbSet<Service> Services { get; set; }
    }
}

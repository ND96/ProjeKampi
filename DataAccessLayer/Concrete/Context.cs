﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=CoreBlogDb;integrated security=true");

            //optionsBuilder.UseSqlServer("Server=.;Database=CoreBlogDb;User Id=sa;Password=1234;TrustServerCertificate=true");

            optionsBuilder.UseSqlServer("Server=.;Database=CoreBlogDb; Trusted_Connection=True;TrustServerCertificate=true");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter>NewsLetters  { get; set; }
        public DbSet<BlogRayting> BlogsRaytings { get; set; }


    }
}

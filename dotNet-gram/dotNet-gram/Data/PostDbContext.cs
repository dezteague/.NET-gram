using dotNet_gram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_gram.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
               new Post
               {
                   ID=1,
                   Title="awesome",
                   Caption="This is awesome!",
                   URL="awesome.jpg",
                   Username="Deziree T."
               },
               new Post
               {
                   ID = 2,
                   Title = "cool",
                   Caption = "This is cool!",
                   URL = "cool.jpg",
                   Username="Elisha C."
               },
               new Post
               {
                   ID = 3,
                   Title = "fun",
                   Caption = "This is fun!",
                   URL = "fun.jpg",
                   Username="Quinton R."
               },
               new Post
               {
                   ID = 4,
                   Title = "amazing",
                   Caption = "This is amazing!",
                   URL = "amazing.jpg",
                   Username="Zan J."
               },
               new Post
               {
                   ID = 5,
                   Title = "beautiful",
                   Caption = "This is beautiful",
                   URL = "beautiful.jpg",
                   Username="Lynette E."
               }
                );
        }

        //db table
        public DbSet<Post> Posts { get; set; }
    }
}

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
                   Rating=5,
                   URL="awesome.jpg"
               },
               new Post
               {
                   ID = 2,
                   Title = "cool",
                   Caption = "This is cool!",
                   Rating = 4,
                   URL = "cool.jpg"
               },
               new Post
               {
                   ID = 3,
                   Title = "fun",
                   Caption = "This is fun!",
                   Rating = 3,
                   URL = "fun.jpg"
               },
               new Post
               {
                   ID = 4,
                   Title = "amazing",
                   Caption = "This is amazing!",
                   Rating = 5,
                   URL = "amazing.jpg"
               },
               new Post
               {
                   ID = 5,
                   Title = "beautiful",
                   Caption = "This is beautiful!",
                   Rating = 5,
                   URL = "beautiful.jpg"
               }
                );
        }

        //db table
        public DbSet<Post> Posts { get; set; }
    }
}

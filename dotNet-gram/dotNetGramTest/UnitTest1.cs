using Xunit;
using dotNet_gram.Models;
using dotNet_gram.Models.Services;
using dotNet_gram.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dotNetGramTest
{
    public class UnitTest1
    {
        [Fact]
        public async void CanCreatePostTest()
        {
            //testing post manger service
            DbContextOptions<PostDbContext> options =
                new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreatePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {
                //arrange
                Post post = new Post();
                post.ID = 1;
                post.Title = "Fun";
                post.Caption = "in the sun";
                post.URL = "www.funinthesun.com";
                //act 
                PostManager postservice = new PostManager(context);

                await postservice.SaveAsync(post);

                var result = context.Posts.FirstOrDefault(p => p.ID == p.ID);
                //assert
                Assert.Equal(post, result);
            }
        }

        [Fact]
        public async void CanDeletePostTest()
        {
            //testing post manger service
            DbContextOptions<PostDbContext> options =
                new DbContextOptionsBuilder<PostDbContext>().UseInMemoryDatabase("CreatePost").Options;

            using (PostDbContext context = new PostDbContext(options))
            {

                //arrange
                Post post = new Post();
                post.ID = 1;
                post.Title = "Fun";
                post.Caption = "in the sun";
                post.URL = "www.funinthesun.com";
                //act 
                PostManager postservice = new PostManager(context);

                await postservice.SaveAsync(post);
                await postservice.DeleteAsync(1);

                var result = context.Posts.FirstOrDefault(p => p.ID == 1);
                //assert
                Assert.Null(post);
            }
        }
    }
}

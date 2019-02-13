using dotNet_gram.Data;
using dotNet_gram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_gram.Models.Services
{
    //service contains the logic for each task in the interface
    //service depends on the database

    public class PostManager : IPost
    {
        private readonly PostDbContext _context;

        public PostManager(PostDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            //check to see if the post exists in the db
            Post post = await _context.Posts.FindAsync(id);
            
            if(post !=null)
            {
                _context.Remove(post);
                //remove and save the changes
                await _context.SaveChangesAsync();
            }
        }

        public Task<Post> FindPost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetPosts()
        {
            //return a list of all the posts in the db
            return await _context.Posts.ToListAsync();
        }

        public Task SaveAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

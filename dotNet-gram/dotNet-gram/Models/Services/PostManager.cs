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

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns>home page</returns>
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

        /// <summary>
        /// find a post
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns>post</returns>
        public async Task<Post> FindPost(int id)
        {
            //find a post by its id
            Post post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        /// <summary>
        /// get all posts
        /// </summary>
        /// <returns>all posts</returns>
        public async Task<List<Post>> GetPosts()
        {
            //return a list of all the posts in the db
            return await _context.Posts.ToListAsync();
        }

        /// <summary>
        /// save a new post or changes to an exisiting post
        /// </summary>
        /// <param name="post">post id</param>
        /// <returns>new post or updated post</returns>
        public async Task SaveAsync(Post post)
        {
            //look for the post in the db
            if(await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID) == null)
            {
                //if it doesn't exist, add it
                _context.Posts.Add(post);
            }
            else
            {
                //update the db with a new post
                _context.Posts.Update(post);
            }
            //save changes to the db
            await _context.SaveChangesAsync();
        }
    }
}

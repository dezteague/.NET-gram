using dotNet_gram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_gram.Models.Services
{
    public class PostManager : IPost
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> FindPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

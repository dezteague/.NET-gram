using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_gram.Models.Interfaces
{
    public interface IPost
    {
        //GetAll
        Task<List<Post>> GetPosts();

        //Find
        Task<Post> FindPost(int id);

        //Save
        Task SaveAsync(Post post);

        //Delete
        Task DeleteAsync(int id);
    }
}

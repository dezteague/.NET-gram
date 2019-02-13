using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet_gram.Models;
using dotNet_gram.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNet_gram.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly IPost _post;

        [FromRoute]
        public int ID { get; set; }

        public Post Post { get; set; }

        public ManageModel(IPost post)
        {
            _post = post;
        }

        public async Task OnGet()
        {
            Post = await _post.FindPost(ID);
        }
    }
}
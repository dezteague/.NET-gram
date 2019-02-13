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
        public int? ID { get; set; }
        
        //bind property allows user to keep information input in the form 
        [BindProperty]
        public Post Post { get; set; }

        public ManageModel(IPost post)
        {
            _post = post;
        }

        public async Task OnGet()
        {
            //if there's no post, create a new one
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        public async Task<IActionResult> OnPost()
        {
            //call to db with the ID
            //if there is no post, create a new one
            var pst = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();

            //set data from the db to the new data from Post/user input
            pst.Title = Post.Title;
            pst.Caption = Post.Caption;
            pst.Rating = Post.Rating;

            //save the post to the db
            await _post.SaveAsync(pst);

            return RedirectToPage("/Posts/Index", new { id = pst.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}
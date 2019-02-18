using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotNet_gram.Models;
using dotNet_gram.Models.Interfaces;
using dotNet_gram.Models.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

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

        [BindProperty]
        public IFormFile Image { get; set; }

        public Blob BlobImage { get; set; }

        public ManageModel(IPost post, IConfiguration configuration)
        {
            _post = post;

            //blob storage account reference
            BlobImage = new Blob(configuration);
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
            pst.Username = Post.Username;
           
            if(Image != null)
            {
                //Azure blob
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                //get container
                var container = await BlobImage.GetContainer("postimages");

                //upload image
                BlobImage.UploadFile(container, Image.FileName, filePath);

                //get uploaded image
                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                //update the db image for the post
                pst.URL = blob.Uri.ToString();
            }

            //save the post to the db
            await _post.SaveAsync(pst);

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}
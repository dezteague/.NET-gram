using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_gram.Models
{
    public class Post
    {
        //properties of each post
        
        public int ID { get; set; }
        
        public string Title { get; set; }

        public string Username { get; set; }

        public string Caption { get; set; }

        public string URL { get; set; }
    }
}

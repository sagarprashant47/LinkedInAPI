using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public string Comments { get; set; }
        public DateTime? PostDateTime { get; set; }
        public List<Comment> PostComments { get; set; } = new List<Comment>();
        public List<Like> PostLikes { get; set; } = new List<Like>(); 
    }
    public class Comment
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public string Comments { get; set; }
        public DateTime? CommentDateTime { get; set; }
    }
    public class Like
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public DateTime? LikeDateTime { get; set; }
    }
    

}

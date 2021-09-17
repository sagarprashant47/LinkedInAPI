using LinkedInAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static List<Post> posts = new List<Post>();
        public static List<Comment> comments = new List<Comment>();
        public static List<Like> likes = new List<Like>();

        [HttpGet]
        public List<Post> Get()
        {

            return posts;
            //return new Post[] {
            //    new Post(){Comments="coments", Likes=1 ,Text ="text" , Id=1,PostDateTime=DateTime.Now} 
            //};
        }

        [HttpPost]
        [Route("UpdatePost")]
        public void UpdatePost(Post model)
        {
            model.Id= posts.Count + 1;
            model.PostDateTime = DateTime.UtcNow;
            posts.Add(model);

        }

        [HttpPost]
        [Route("AddComment/{postId}")]
        public Post AddComment(int postId, Comment model)
        {
            model.CommentDateTime = DateTime.UtcNow;
            model.Id = comments.Count + 1;
            model.PostId = postId;
            comments.Add(model);
            posts.Where(x => x.Id == postId).FirstOrDefault().PostComments.Add(model);
            return posts.Where(x => x.Id == postId).FirstOrDefault();
        }

        [HttpGet]
        [Route("AddLike/{postId}")]
        public Post AddLike(int postId)
        {
            Like model = new Like();
            model.LikeDateTime = DateTime.UtcNow;
            model.Id = likes.Count + 1;
            model.PostId = postId;
            likes.Add(model);
            posts.Where(x => x.Id == postId).FirstOrDefault().PostLikes.Add(model);
            return posts.Where(x => x.Id == postId).FirstOrDefault();
        }
    }
}

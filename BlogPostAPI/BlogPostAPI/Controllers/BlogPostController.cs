using BlogPost.Model;
using BlogPost.Model.DTO;
using BlogPost.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/BlogPost")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostController(IBlogPostRepository blogPostRepository) {
            _blogPostRepository = blogPostRepository;
        }
        [HttpGet("GetAllBlogs")]
        public IActionResult GetAllBlogs()
        {
            try
            {
                List<Blog>? blog = _blogPostRepository.GetBlogList();
                return Ok(blog);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetBlogById/{id}")]
        public IActionResult GetBlogsById(int id)
        {
            try
            {
                Blog? blog = _blogPostRepository.GetBlogById(id);
                return Ok(blog);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("InsertBlogPost")]
        public IActionResult InsertBlogPost([FromBody]BlogPostDto blogPostDto)
        {
            try
            {
                BlogPostDto objBlogPostDto =  _blogPostRepository.InsertBlogPost(blogPostDto).Result;
                return CreatedAtAction(nameof(GetBlogsById),new {Id = objBlogPostDto .Id}, blogPostDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("DeleteBlogPost/{id}")]
        public IActionResult DeleteBlogPost(int id)
        {
            try
            {
                _blogPostRepository.DeleteBlogPost(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("UpdateBlogPost")]
        public IActionResult UpdateBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            try
            {
                BlogPostDto objBlogPostDto = _blogPostRepository.UpdateBlogPost(blogPostDto).Result;
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

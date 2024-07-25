using BlogPost.Model;
using BlogPost.Model.DTO;
using System;
namespace BlogPost.Repository.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPostDto> InsertBlogPost(BlogPostDto blogPostDto);
        Task<BlogPostDto> UpdateBlogPost(BlogPostDto blogPostDto);
        void DeleteBlogPost(int id);
        List<Blog>? GetBlogList();
        Blog? GetBlogById(int id);

    }
}

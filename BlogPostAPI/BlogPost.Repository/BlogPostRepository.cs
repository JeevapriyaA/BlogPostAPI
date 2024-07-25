using BlogPost.Model;
using BlogPost.Model.DTO;
using BlogPost.Repository.Interface;
using Newtonsoft.Json;

namespace BlogPost.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly string _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "blogpost.json");

        public BlogPostRepository()
        {
            //Constructor Part to Inject Services
        }

        public Task<BlogPostDto> InsertBlogPost(BlogPostDto blogPostDto)
        {
            try
            {
                List<Blog>? blogList = GetBlogList();

                Blog blog = new Blog();

                int max = blogList?.Any() == true ? Enumerable.Max(blogList, blog => blog.Id) : 0;
                blog.Id = max + 1;

                blog.UserName = blogPostDto.UserName;
                blog.Text = blogPostDto.Text;
                blog.DateCreated = DateTime.Now;

                blogList?.Add(blog);
                File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(blogList));
                return Task.FromResult(blogPostDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<BlogPostDto> UpdateBlogPost(BlogPostDto blogPostDto)
        {
            try
            {
                List<Blog>? blogList = GetBlogList();
                int index = blogList?.Any() == true ? blogList.FindIndex(m => m.Id == blogPostDto.Id) : -1;
                if (index != -1 && blogList?.Any() == true)
                {
                    blogList[index].Text = blogPostDto.Text;
                    blogList[index].UserName = blogPostDto.UserName;
                    blogList[index].DateCreated = DateTime.Now;

                    File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(blogList));
                }
                return Task.FromResult(blogPostDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteBlogPost(int id)
        {
            try
            {
                List<Blog>? blogList = GetBlogList();
                Blog? objBlog = blogList?.Any() == true ? blogList.FirstOrDefault(m => m.Id == id) : null;
                if (objBlog != null && blogList != null)
                {
                    blogList.Remove(objBlog);
                    File.WriteAllText(_jsonPath, JsonConvert.SerializeObject(blogList));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Blog>? GetBlogList()
        {
            try
            {
                var jsonResult = File.ReadAllText(_jsonPath);
                return JsonConvert.DeserializeObject<List<Blog>>(jsonResult);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Blog? GetBlogById(int id)
        {
            try
            {
                List<Blog>? blogs = GetBlogList();
                return blogs?.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
using AutoMapper;
using BlogPost.Model;
using BlogPost.Model.DTO;
using BlogPost.Repository.Interface;
using BlogPostAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BlogPost.UnitTest
{
    public class BlogPostUnitTest
    {
        private readonly Mock<IBlogPostRepository> _mockRepository;
        private readonly BlogPostController _controller;
        private List<Blog> blogList = new List<Blog>()
{
    new Blog
    {
        Id = 1,
        UserName = "RAJ",
        DateCreated = DateTime.Now,
        Text="Commands.."
    }
};
        public BlogPostUnitTest()
        {
            _mockRepository = new Mock<IBlogPostRepository>();
            _controller = new BlogPostController(_mockRepository.Object);
        }

        [Fact]
        public void GetBlogPost_CheckStatusCode()
        {

            _mockRepository
                .Setup(x => x.GetBlogList())
                .Returns(blogList);
            var _sut = new BlogPostController(_mockRepository.Object);

            var result = _sut.GetAllBlogs();

            Assert.NotNull(result);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Blog>>(objectResult.Value);
            var modelCount = model.Count();
            Assert.Equal(1, modelCount);
        }
        [Fact]
        public async Task GetBlog_ReturnsBlogExsits()
        {
            // Arrange
            var userId = 1;
            var expectedBlog = new Blog
            {
                Id = 1,
                UserName = "RAJ",
                DateCreated = DateTime.Now,
                Text = "Commands.."
            };
           
            var controller = new BlogPostController(_mockRepository.Object);

            var result = controller.GetBlogsById(userId);

            Assert.NotNull(result);
            Assert.Equal(expectedBlog.UserName, result.ToString());
        }
        [Fact]
        public async Task GivenBlogRequest_WhenRun_ThenHandlerResultReturned()
        {
            // arrange
            var blogRequest = new BlogPostDto
            {
                Id=0,
                UserName="RAJ",
                Text="Commands"
            };

            _mockRepository
                .Setup(x => x.InsertBlogPost(blogRequest));
            
            var result = _controller.InsertBlogPost(blogRequest);

            _mockRepository
                .Verify(x => x.InsertBlogPost(blogRequest), Times.Once);


            Assert.Equal("RAJ", result.ToString()); Assert.Equal("RAJ", result.ToString());
        }
        [Fact]
        public async Task GivenBlogRequestUpdate_WhenRun_ThenHandlerResultReturned()
        {
            // arrange
            var blogRequest = new BlogPostDto
            {
                Id = 1,
                UserName = "RAJ",
                Text = "Commands"
            };

            _mockRepository
                .Setup(x => x.UpdateBlogPost(blogRequest));

            var result = _controller.UpdateBlogPost(blogRequest);

            _mockRepository
                .Verify(x => x.UpdateBlogPost(blogRequest), Times.Once);


            Assert.Equal("RAJ", result.ToString());
        }
    }
}
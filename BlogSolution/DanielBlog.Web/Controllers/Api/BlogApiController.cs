using DanielBlog.Web.Models.Domain;
using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.Response;
using DanielBlog.Web.Models.Shared;
using DanielBlog.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DanielBlog.Web.Controllers.Api
{
    [RoutePrefix("api/blog")]
    public class BlogApiController : ApiController
    {
        //Get Blogs
        [Route(""), HttpGet]
        public HttpResponseMessage GetBlogs()
        {
            BlogService service = new BlogService();
            ItemsResponse<Blog> response = new ItemsResponse<Blog>();
            response.Items = service.BlogSelectAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        //Insert Blog
        [Route(""), HttpPost]
        public HttpResponseMessage PostBlog(BlogAddRequest payload) 
        {
            BlogService service = new BlogService();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = service.BlogInsert(payload);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //Update Blog
        [Route(""), HttpPut]
        public HttpResponseMessage UpdateBlog(BlogUpdateRequest payload)
        {
            BlogService service = new BlogService();
            SuccessResponse response = new SuccessResponse();
            service.BlogUpdate(payload);
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //Delete Blog
        [Route("{id}"), HttpDelete]
        public HttpResponseMessage DeleteBlog(int id)
        {
            BlogService service = new BlogService();
            SuccessResponse response = new SuccessResponse();
            service.BlogDelete(id);
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        //Get Blog with Comments
        [Route("{blogId}"), HttpGet]
        public HttpResponseMessage GetBlogWithComments(int blogId)
        {
            BlogService service = new BlogService();
            Blog blog = new Blog();
            blog = service.BlogSelectById(blogId);
            blog.Comments = service.GetCommentsByBlogId(blogId);
            return Request.CreateResponse(HttpStatusCode.OK, blog);
        }
        //Insert Comment
        [Route("Comment"), HttpPost]
        public HttpResponseMessage PostComment(CommentAddRequest payload)
        {
            BlogService service = new BlogService();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = service.CommentInsert(payload);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //Update Comment
        [Route("Comment"), HttpPut]
        public HttpResponseMessage UpdateComment(CommentUpdateRequest payload)
        {
            BlogService service = new BlogService();
            SuccessResponse response = new SuccessResponse();
            service.CommentUpdate(payload);
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //Delete Comment         
        [Route("Comment/{id}"), HttpDelete]
        public HttpResponseMessage DeleteComment(int id)
        {
            BlogService service = new BlogService();
            SuccessResponse response = new SuccessResponse();
            service.CommentDelete(id);
            response.IsSuccessful = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}

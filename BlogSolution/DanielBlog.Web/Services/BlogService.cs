using DanielBlog.Web.Models.Domain;
using DanielBlog.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Services
{
    public class BlogService
    {
        //Blog Related Code

        public List<Blog> BlogSelectAll()
        {
            List<Blog> blogList = new List<Blog>();

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_SelectAll", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Blog b = new Blog();
                        b.ID = reader.GetInt32(0);
                        b.Title = reader.GetString(1);
                        b.Content = reader.GetString(2);
                        b.AuthorGuid = reader.GetString(3);
                        b.DateCreated = reader.GetDateTime(4);
                        b.DateModified = reader.GetDateTime(5);
                        blogList.Add(b);
                    }
                }
            }

            return blogList;
        }

        public Blog BlogSelectById(int id)
        {
            Blog b = new Blog();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_SelectById", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        b.ID = reader.GetInt32(0);
                        b.Title = reader.GetString(1);
                        b.Content = reader.GetString(2);
                        b.AuthorGuid = reader.GetString(3);
                        b.DateCreated = reader.GetDateTime(4);
                        b.DateModified = reader.GetDateTime(5);
                    }
                }
            }
            return b;
        }

        public int BlogInsert(BlogAddRequest payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", payload.Title);
                    cmd.Parameters.AddWithValue("@Content", payload.Content);
                    cmd.Parameters.AddWithValue("@AuthorGuid", payload.AuthorGuid);


                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }
            }
            return id;
        }

        public void BlogUpdate(BlogUpdateRequest payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_Update", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@Title", payload.Title);
                    cmd.Parameters.AddWithValue("@Content", payload.Content);
                    cmd.Parameters.AddWithValue("@AuthorGuid", payload.AuthorGuid);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BlogDelete(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_Delete", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }


        //Comment Related Code
        public List<Comment> GetCommentsByBlogId(int blogId)
        {
            List<Comment> list = null;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("BlogComment_SelectByBlogId", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogId", blogId);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {

                        Comment comment = BindBlogComment(reader);
                        if (list == null)
                        {
                            list = new List<Comment>();
                        }
                        list.Add(comment);

                    }
                }
            }
            return list;
        }

        private static Comment BindBlogComment(IDataReader reader)
        {
            Comment comment = new Comment();
            int startingIndex = 0; //startingOrdinal

            comment.ID = reader.GetInt32(startingIndex++);
            comment.BlogID = reader.GetInt32(startingIndex++);
            comment.ParentCommentId = GetSafeInt32(reader, startingIndex++);
            comment.Title = reader.GetString(startingIndex++);
            comment.Content = reader.GetString(startingIndex++);
            comment.UserName = reader.GetString(startingIndex++);
            comment.DateCreated = reader.GetDateTime(startingIndex++);
            comment.DateModified = reader.GetDateTime(startingIndex++);

            comment.Replies = BlogCommentSelectReplies(comment.ID);

            return comment;
        }

        private static int GetSafeInt32(IDataReader reader, Int32 ordinal)
        {
            if (reader[ordinal] != null && Convert.IsDBNull(reader[ordinal]) == false)
            {
                return reader.GetInt32(ordinal);
            }
            else
            {
                return 0;
            }
        }

        private static List<Comment> BlogCommentSelectReplies(int parentCommentId)
        {
            List<Comment> list = null;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("BlogComment_SelectByParentCommentId", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ParentCommentId", parentCommentId);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Comment comment = BindBlogComment(reader);
                        if (list == null)
                        {
                            list = new List<Comment>();

                        }
                        list.Add(comment);

                    };
                    return list;
                }
            }
        }

        //Used for Editing Comments
        public Comment CommentSelectById(int id)
        {
            Comment c = new Comment();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("BlogComment_SelectById", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        c.ID = reader.GetInt32(0);
                        c.Title = reader.GetString(1);
                        c.Content = reader.GetString(2);
                    }
                }
            }
            return c;
        }

        public int CommentInsert(CommentAddRequest payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("BlogComment_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogId", payload.BlogId);
                    cmd.Parameters.AddWithValue("@ParentCommentId", payload.ParentCommentId);
                    cmd.Parameters.AddWithValue("@Title", payload.Title);
                    cmd.Parameters.AddWithValue("@Content", payload.Content);
                    cmd.Parameters.AddWithValue("@UserName", payload.Name);


                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;

                }
            }
            return id;
        }

        public void CommentUpdate(CommentUpdateRequest payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("BlogComment_Update", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@BlogId", payload.BlogId);
                    cmd.Parameters.AddWithValue("@ParentCommentId", payload.ParentCommentId);
                    cmd.Parameters.AddWithValue("@Title", payload.Title);
                    cmd.Parameters.AddWithValue("@Content", payload.Content);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CommentDelete(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("BlogComment_Delete", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }


    }
}
using DanielBlog.Web.Models.Domain;
using DanielBlog.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Services
{
    public class BlogService
    {
        public List<Blog> GetAllBlogs()
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

        public Blog GetBlogById(int id)
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

        public Blog GetBlogAndCommentsById(int id)
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


        public int PersonInsert(PersonAddRequest payload)
        {
            int id = 0;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("People_Insert", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", payload.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", payload.LastName);

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

        public void PersonUpdate(PersonUpdateRequest payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("People_Update", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", payload.Id);
                    cmd.Parameters.AddWithValue("@FirstName", payload.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", payload.LastName);

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void PersonDelete(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("People_Delete", sqlConn))
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
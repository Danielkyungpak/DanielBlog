using DanielBlog.Web.Models.Domain;
using DanielBlog.Web.Models.Requests;
using DanielBlog.Web.Models.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DanielBlog.Web.Services
{
    public class PeopleService
    {
        public List<Person> GetPeople()
        {
            List<Person> peopleList = new List<Person>();

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("People_SelectAll", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Person p = new Person();
                        p.Id = reader.GetInt32(0);
                        p.FirstName = reader.GetString(1);
                        p.LastName = reader.GetString(2);
                        peopleList.Add(p);

                    }
                }

            }

            return peopleList;
        }

        public Person GetPerson(int id)
        {
            Person p = new Person();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("People_SelectById", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        p.Id = reader.GetInt32(0);
                        p.FirstName = reader.GetString(1);
                        p.LastName = reader.GetString(2);
                    }
                }

            }
            return p;
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
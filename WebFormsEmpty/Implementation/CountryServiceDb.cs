using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFormsEmpty.Interfaces;
using WebFormsEmpty.Models;

namespace WebFormsEmpty.Implementation
{
    public class CountryServiceDb : ICountryService
    {
        public void Add(Country country)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Country (Name,Capital) values ('" + country.Name + "', '"+ country.Capital+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Country where id = " + Id, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
            }
        }

        public List<Country> getAll_1()
        {
            List<Country> result = new List<Country>();
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Country", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                result = ds.Tables[0].AsEnumerable().Select(z => new Country
                {
                    Id = z.Field<int>("Id"),
                    Name = z.Field<string>("Name"),
                    Capital = z.Field<string>("Capital")
                }).ToList();

                //foreach (DataRow item in ds.Tables[0].Rows)
                //{
                //    result.Add(new Country()
                //    {
                //        Id = Convert.ToInt32(item["Id"].ToString()),
                //        Name = item["Name"].ToString(),
                //        Capital = item["Capital"].ToString()
                //    });
                //}
                //da.Fill(dt);
                //foreach (DataRow item in dt.Rows)
                //{
                //    result.Add(new Country()
                //    {
                //        Id = Convert.ToInt32(item["Id"].ToString()),
                //        Name = item["Name"].ToString(),
                //        Capital = item["Capital"].ToString()
                //    });
                //}
                //SqlDataReader dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{                    
                //    result.Add(new Country() {
                //        Id = Convert.ToInt32(dr["Id"].ToString()),
                //        Name = dr["Name"].ToString(),
                //        Capital = dr["Capital"].ToString()
                //    });
                //}
                conn.Close();
                cmd.Dispose();
            }
            return result;
        }

        public IEnumerable<Country> getAll_2()
        {
            IEnumerable<Country> result = new List<Country>();            
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Country", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                result = ds.Tables[0].AsEnumerable().Select(z => new Country
                {
                    Id = z.Field<int>("Id"),
                    Name = z.Field<string>("Name"),
                    Capital = z.Field<string>("Capital")
                }).ToList();               
                conn.Close();
                cmd.Dispose();
            }
            return result;
        }

        public Country getById(int Id)
        {
            List<Country> result = new List<Country>();
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Country where id = "+Id, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                result = ds.Tables[0].AsEnumerable().Select(z => new Country
                {
                    Id = z.Field<int>("Id"),
                    Name = z.Field<string>("Name"),
                    Capital = z.Field<string>("Capital")
                }).ToList();
                conn.Close();
                cmd.Dispose();
            }            
            return result[0];
        }

        public IEnumerable<Country> getByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Update_1(Country country)
        {
            throw new NotImplementedException();
        }

        public void Update_2(int Id, Country country)
        {
            throw new NotImplementedException();
        }

        public void Update_3(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
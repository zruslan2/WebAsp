using Dapper;
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
    public class CountryServiceDapper : ICountryService
    {
        public void Add(Country country)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                //db.Execute("insert into Country (Name,Capital) values ('" + country.Name + "', '" + country.Capital + "')", commandType: CommandType.Text);
                db.Execute("insert into Country (Name,Capital) values (@Name,@Capital)",new {Name = country.Name, Capital = country.Capital }, commandType: CommandType.Text);
            }
        }
        public void Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {                
                db.Execute("delete from Country where id = "+Id, commandType: CommandType.Text);
            }
        }

        public List<Country> getAll_1()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                return db.Query<Country>("select * from country", commandType: CommandType.Text).ToList();
            }
        }

        public IEnumerable<Country> getAll_2()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                return db.Query<Country>("select * from country", commandType: CommandType.Text).ToList();
            }
        }

        public Country getById(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                return db.Query<Country>("select * from country where Id = " + Id, commandType: CommandType.Text).FirstOrDefault();
            }
        }

        public IEnumerable<Country> getByName(string Name)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                return db.Query<Country>("select * from country where Name = " + Name, commandType: CommandType.Text).ToList();
            }
        }

        public void Update_1(Country country)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString))
            {
                db.Execute("update Country set Name = @Name, Capital = @Capital where id = @Id",new {Name = country.Name, Capital = country.Capital, id = country.Id }, commandType: CommandType.Text);
            }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsEmpty.Interfaces;
using WebFormsEmpty.Models;

namespace WebFormsEmpty.Implementation
{
    public class CountryServiceEf : ICountryService
    {
        Context context;
        public CountryServiceEf()
        {
            context = new Context();
        }
        public void Add(Country country)
        {
            context.Country.Add(country);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Country country = context.Country.FirstOrDefault(p => p.Id == Id);
            context.Country.Remove(country);
            context.SaveChanges();
        }

        public List<Country> getAll_1()
        {
            return context.Country.ToList();
        }

        public IEnumerable<Country> getAll_2()
        {
            return context.Country.ToList();
        }

        public Country getById(int Id)
        {
            return context.Country.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Country> getByName(string Name)
        {
            return context.Country.Where(p => p.Name == Name).ToList();
        }

        public void Update_1(Country country)
        {
            Country country1 = context.Country.FirstOrDefault(p => p.Id == country.Id);
            country1.Name = country.Name;
            country1.Capital = country.Capital;
            context.SaveChanges();
        }

        public void Update_2(int Id, Country country)
        {
            Country country1 = context.Country.FirstOrDefault(p => p.Id == country.Id);
            context.Entry(country1).CurrentValues.SetValues(country);
        }

        public void Update_3(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
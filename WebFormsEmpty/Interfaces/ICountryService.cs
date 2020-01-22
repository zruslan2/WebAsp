using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsEmpty.Models;

namespace WebFormsEmpty.Interfaces
{
    public interface ICountryService
    {
        List<Country> getAll_1();
        IEnumerable<Country> getAll_2();
        void Add(Country country);
        Country getById(int Id);
        IEnumerable<Country> getByName(string Name);
        void Update_1(Country country);
        void Update_2(int Id, Country country);
        void Update_3(Country country);
        void Delete(int Id);
    }
}

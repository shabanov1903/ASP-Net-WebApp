using GeekBrains.TimeSheets.DB.Context;
using GeekBrains.TimeSheets.DB.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public class ListRepository : IPersonRepository
    {
        private List<PersonContext> _listDataBase;
        public ListRepository(List<PersonContext> listDataBase) => _listDataBase = listDataBase;
        public async Task AddPersonAsync(PersonContext person)
        {
            if (_listDataBase.Exists(x => x.Id == person.Id)) throw new PersonFoundException("Данный элемент уже существует");
            await Task.Run(() => _listDataBase.Add(person));
        }

        public async Task ChangePersonAsync(PersonContext person)
        {
            var element = await GetPersonByIdAsync(person.Id);
            element.Id = person.Id;
            element.FirstName = person.FirstName;
            element.LastName = person.LastName;
            element.Email = person.Email;
            element.Company = person.Company;
            element.Age = person.Age;
        }

        public async Task DeletePersonByIdAsync(int id)
        {
            var element = await GetPersonByIdAsync(id);
            _listDataBase.Remove(element);
        }

        public async Task<PersonContext> GetPersonByIdAsync(int id)
        {
            return await Task.Run<PersonContext>(() => {
                   if (_listDataBase.Exists(x => x.Id == id))
                   {
                       return _listDataBase.Find(x => x.Id == id);
                   }
                   throw new PersonFoundException("Данный элемент не существует");
            });
        }

        public async Task<PersonContext> GetPersonByNameAsync(string name)
        {
            return await Task.Run<PersonContext>(() => {
                   if (_listDataBase.Exists(x => x.FirstName == name))
                   {
                       return _listDataBase.Find(x => x.FirstName == name);
                   }
                   throw new PersonFoundException("Данный элемент не существует");
            });
        }

        public async Task<List<PersonContext>> GetPersonsByIdAsync(int startId, int quantity)
        {
            var element = await GetPersonByIdAsync(startId);
            var num = _listDataBase.IndexOf(element);
            return await Task.Run<List<PersonContext>>(() => {
                return _listDataBase.GetRange(num, quantity);
            });
        }
    }
}

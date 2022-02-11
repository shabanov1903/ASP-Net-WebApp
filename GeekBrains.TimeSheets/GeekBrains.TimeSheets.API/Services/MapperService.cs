using GeekBrains.TimeSheets.API.DTO;
using GeekBrains.TimeSheets.DB.Context;
using System.Reflection;

namespace GeekBrains.TimeSheets.API.Services
{
    public class MapperService
    {
        public PersonDTO Map(PersonContext context)
        {
            return new PersonDTO()
            {
                Id = context.Id,
                FirstName = context.FirstName,
                LastName = context.LastName,
                Email = context.Email,
                Company = context.Company,
                Age = context.Age
            };
        }

        public List<PersonDTO> Map(List<PersonContext> contextlist)
        {
            var dtoList = new List<PersonDTO>();
            contextlist.ForEach(elem => dtoList.Add(Map(elem)));
            return dtoList;
        }

        public PersonContext Map(PersonDTO dto)
        {
            return new PersonContext()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Company = dto.Company,
                Age = dto.Age
            };
        }
    }
}

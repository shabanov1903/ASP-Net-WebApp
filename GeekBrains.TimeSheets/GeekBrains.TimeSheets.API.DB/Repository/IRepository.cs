using GeekBrains.TimeSheets.DB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Получение объекта по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        Task<PersonContext> GetPersonByIdAsync(int id);

        /// <summary>
        /// Получение объекта по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        Task<PersonContext> GetPersonByNameAsync(string name);

        /// <summary>
        /// Получение перечня объектов от стартового номера определенной длины
        /// </summary>
        /// <param name="startId">Стартовый номер</param>
        /// <param name="quantity">Длина</param>
        /// <returns></returns>
        Task<List<PersonContext>> GetPersonsByIdAsync(int startId, int quantity);

        /// <summary>
        /// Добавление объекта
        /// </summary>
        /// <param name="person">Добавляемый объект</param>
        /// <returns></returns>
        Task AddPersonAsync(PersonContext person);

        /// <summary>
        /// Изменение объекта
        /// </summary>
        /// <param name="person">Изменяемый объект</param>
        /// <returns></returns>
        Task ChangePersonAsync(PersonContext person);

        /// <summary>
        /// Удаление объекта по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        Task DeletePersonByIdAsync(int id);
    }
}

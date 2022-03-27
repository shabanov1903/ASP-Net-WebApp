using GeekBrains.TimeSheets.DB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.DB.Repository
{
<<<<<<< HEAD:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API.DB/Repository/IPersonRepository.cs
    /// <summary>
    /// Иснерфейс для связи с источником данных
    /// </summary>
    public interface IPersonRepository
=======
    public interface IRepository<TContext>
>>>>>>> lesson4:GeekBrains.TimeSheets/GeekBrains.TimeSheets.API.DB/Repository/IRepository.cs
    {
        /// <summary> Добавление объекта в базу данных </summary>
        Task Create(TContext context);

        /// <summary> Получение объекта из базы данных </summary>
        Task<TContext> Read(Guid id);

        /// <summary> Обновление объекта в базе данных </summary>
        Task Update(TContext context);

        /// <summary> Удаление объекта из базы данных </summary>
        Task Delete(Guid id);
    }
}

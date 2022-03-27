using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains.TimeSheets.Domain.Operations
{
    public interface IDomainRepository<TModel>
    {
        /// <summary> Добавление объекта в базу данных </summary>
        Task Create(TModel context);

        /// <summary> Получение объекта из базы данных </summary>
        Task<TModel> Read(Guid id);

        /// <summary> Обновление объекта в базе данных </summary>
        Task Update(TModel context);

        /// <summary> Удаление объекта из базы данных </summary>
        Task Delete(Guid id);
    }
}

using Shared.Models.Tabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IBaseRepository <TModel, TId> where TModel : class
    {
        /// <summary>
        /// Получает запись по ID
        /// </summary>
        /// <param name="id">ID записи</param>
        /// <returns>Запись если нашел или null</returns>
        Task<Pump?> GetAsync(TId id);
        /// <summary>
        /// Получает все записи
        /// </summary>
        /// <returns>Все записи</returns>
        Task<List<TModel>> GetListAsync();
    }
}

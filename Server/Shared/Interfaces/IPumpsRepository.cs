using Shared.Models.Tabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IPumpsRepository : IBaseRepository<Pump, int>
    {
        /// <summary>
        /// Получение записей постранично
        /// </summary>
        /// <param name="skip">Количество записей которое пропускаем</param>
        /// <param name="take">Количество записей которое бурем</param>
        /// <returns>Записи</returns>
        Task<List<Pump>> GetListAsync(int skip, int take);
    }
}

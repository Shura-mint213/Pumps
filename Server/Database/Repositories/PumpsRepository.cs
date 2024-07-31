using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models.Tabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class PumpsRepository : IPumpsRepository
    {
        private readonly PumpsContext _dbContext;
        public PumpsRepository(PumpsContext context) 
        {
            _dbContext = context;    
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public async Task<Pump?> GetAsync(int id)
        {
            return await _dbContext.Pumps.FirstOrDefaultAsync(k => k.PumpId == id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public async Task<List<Pump>> GetListAsync()
        {
            return await _dbContext.Pumps.ToListAsync();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="skip"><inheritdoc/></param>
        /// <param name="take"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public async Task<List<Pump>> GetListAsync(int skip, int take)
        {
            return await _dbContext.Pumps.Skip(skip).Take(take).ToListAsync();
        }

    }
}

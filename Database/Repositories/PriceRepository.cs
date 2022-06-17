using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class PriceRepository
    {
        private PriceDbContext _context;

        public PriceRepository(PriceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Price>> GetAll()
        {
            return await _context.Set<Price>().ToListAsync();
        }

        public Price CreatePrice(Price price)
        {
            _context.Set<Price>().Add(price);
            return price;
        }

        public Price GetById(Guid id)
        {
            return _context.Set<Price>().Find(id);
        }

        public Price UpdatePrice(Price price)
        {
            _context.Entry(price).State = EntityState.Modified;
            return price;
        }

        public Price DeletePrice(Price price)
        {
            _context.Set<Price>().Remove(price);
            return price;
        }
    }
}
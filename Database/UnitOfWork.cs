using System;
using DataBase.Repositories;

namespace Database
{
    public class UnitOfWork
    {
        private PriceDbContext _context;

        private PriceRepository _priceRepository;

        public PriceRepository PriceRepository
        {
            get
            {
                return _priceRepository;
            }
        }

        public UnitOfWork(PriceDbContext context)
        {
            _context = context;
            _priceRepository = new PriceRepository(_context);
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Save()
        {
            try
            {
                BeginTransaction();
                _context.SaveChanges();
                CommitTransaction();
            }
            catch (Exception)
            {
                RollBackTransaction();
                throw;
            }
        }
    }
}

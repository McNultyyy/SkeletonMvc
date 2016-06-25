using System;
using DAL.Repository;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContext _dbContext;

        public UnitOfWork(IContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
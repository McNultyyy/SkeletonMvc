using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
using System.ComponentModel;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Repository.Models.Entities;
using Repository.Repositorys;

namespace IntegrationTest
{
    public class DbTestFixtureBase<TEntity> where TEntity : Entity
    {
        public DbTestFixtureBase()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFramework()
                .AddInMemoryDatabase();

            
        }
    }
}
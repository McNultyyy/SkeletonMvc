using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using BLL.Services;
using DAL.Models.Entities;
using DAL.Repository;
using DependencyInjection;
using Extension;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace IntegrationTest
{
    public abstract class DbTestFixtureBase<TEntity> where TEntity : Entity, new()
    {
        private IEntityService<TEntity> service;
        private IEnumerable<string> _excludedProperties;
        private TransactionScope _transaction;

        [OneTimeSetUp]
        public void Init()
        {
            var container = IoC.GetConfiguredContainer();
            service = container.Resolve<IEntityService<TEntity>>();
            _excludedProperties = new[]
            {
                new TEntity().GetPropertyName(x => x.Id),
                new TEntity().GetPropertyName(x => x.RowVersion)
            };
        }

        [SetUp]
        public void SetUp()
        {
            _transaction = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Dispose();
        }

        protected virtual TEntity CreateEntity()
        {
            var entity = new TEntity();

            var properties = typeof(TEntity)
                .GetProperties()
                .Where(x => !_excludedProperties.Contains(x.Name));

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var propertyValue = propertyType.DefaultValue() ?? propertyType.NewObject();

                property.SetValue(entity, propertyValue);
            }
            return entity;
        }

        protected virtual TEntity UpdateEntity(TEntity entity)
        {
            return entity;
        }

        [Test]
        public void CanCreateEntity()
        {
            var entity = CreateEntity();
            service.Create(entity);

            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.Not.Null);
        }

        [Test]
        public void CanGetEntity()
        {
            var entity = CreateEntity();

            service.Create(entity);

            var retrievedEntity = service.GetById(entity.Id);

            Assert.That(retrievedEntity, Is.Not.Null);

            var properties = typeof(TEntity)
                .GetProperties()
                .Where(x => !_excludedProperties.Contains(x.Name));

            foreach (var property in properties)
            {
                Assert.That(property.GetValue(entity), Is.EqualTo(property.GetValue(retrievedEntity)));
            }
        }

        [Test, Ignore("")]
        public void CanUpdateEntity()
        {
            var entity = CreateEntity();
            service.Create(entity);

            var dbEntity = service.GetById(entity.Id);
            var updatedEntity = UpdateEntity(dbEntity);

            Assert.That(dbEntity, Is.Not.EqualTo(updatedEntity));
        }

        [Test]
        public void CanRemoveEntity()
        {
            var entity = CreateEntity();
            service.Create(entity);

            service.Delete(entity);

            var dbEntity = service.GetById(entity.Id);
            Assert.That(dbEntity, Is.Null);
        }


    }
}
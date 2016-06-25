using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
        private IRepository<TEntity> _repository;
        private IEnumerable<string> _excludedProperties;
        private TransactionScope _transaction;

        [OneTimeSetUp]
        public void Init()
        {
            var container = IoC.GetConfiguredContainer();
            _repository = container.Resolve<IRepository<TEntity>>();
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
            _repository.Add(entity);

            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.Id, Is.Not.Null);
        }

        [Test]
        public void CanRetrieveEntity()
        {
            var entity = CreateEntity();



            _repository.Add(entity);

            var retrievedEntity = _repository.GetById(entity.Id);

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
            _repository.Add(entity);

            var dbEntity = _repository.GetById(entity.Id);
            var updatedEntity = UpdateEntity(dbEntity);

            Assert.That(dbEntity, Is.Not.EqualTo(updatedEntity));
        }

        [Test]
        public void CanRemoveEntity()
        {
            var entity = CreateEntity();
            _repository.Add(entity);

            _repository.Remove(entity);

            var dbEntity = _repository.GetById(entity.Id);
            Assert.That(dbEntity, Is.Null);
        }


    }
}
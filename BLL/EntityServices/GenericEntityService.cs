using System;
using System.Collections.Generic;
using DAL.Models.Entities;
using DAL.Repository;
using DAL.UnitOfWork;

namespace BLL.EntityServices
{
    public class GenericEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : Entity
    {
        private IRepository<TEntity> _repository;
        private IUnitOfWork _unitOfWork;

        public GenericEntityService(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public TEntity GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = _repository.GetAll();
            return entities;
        }
    }
}
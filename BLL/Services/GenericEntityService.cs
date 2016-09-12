using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models.Entities;
using DAL.Repository;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class GenericEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

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

        public async Task CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Add(entity);
            await _unitOfWork.CommitAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public TEntity Get(int id)
        {
            var entity = _repository.Get(id);
            return entity;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = _repository.Get();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _repository.GetAsync();
            return entities;
        }
    }
}
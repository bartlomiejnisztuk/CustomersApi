using System;
using AutoMapper;
using CustomersApi.DAL.Repositories;

namespace CustomersApi.BL.Services
{
    public abstract class BaseService<TEntity,TModel> where TEntity: class
    {
        private readonly BaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected BaseService(BaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public bool Update(TModel model)
        {
            bool isSuccess;

            try
            {
                var entity = _mapper.Map<TModel, TEntity>(model);

                _repository.Update(entity);

                isSuccess = true;
            }
            catch (Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;
        }

        public bool Delete(TModel model)
        {
            bool isSuccess;

            try
            {
                var modelEntity = _mapper.Map<TModel, TEntity>(model);

                _repository.Delete(modelEntity);

                isSuccess = true;
            }
            catch (Exception e)
            {

                isSuccess = false;
            }

            return isSuccess;
        }
    }
}

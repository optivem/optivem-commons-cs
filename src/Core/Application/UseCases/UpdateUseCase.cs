﻿using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class UpdateUseCase<TRequest, TResponse, TEntity, TKey> : IUpdateUseCase<TRequest, TResponse>
        where TRequest : IIdentifiable<TKey>
        where TResponse : class
        where TEntity : class, IEntity<TKey>
    {
        public UpdateUseCase(IRequestMapper<TRequest, TEntity> requestMapper, IResponseMapper<TEntity, TResponse> responseMapper, IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper<TRequest, TEntity> RequestMapper { get; private set; }

        protected IResponseMapper<TEntity, TResponse> ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IRepository<TEntity, TKey> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;

            var exists = await Repository.GetExistsAsync(id);

            if (!exists)
            {
                return null;
            }

            var entity = RequestMapper.Map(request);

            try
            {
                Repository.Update(entity);
                await UnitOfWork.SaveChangesAsync();

                var retrieved = await Repository.GetSingleOrDefaultAsync(id);

                if (retrieved == null)
                {
                    return null;
                }

                var response = ResponseMapper.Map(retrieved);
                return response;
            }
            catch (ConcurrentUpdateException)
            {
                exists = await Repository.GetExistsAsync(id);

                if (!exists)
                {
                    return null;
                }

                throw;
            }
        }
    }
}
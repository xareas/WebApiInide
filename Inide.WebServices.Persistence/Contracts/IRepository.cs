using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Serenity.Data;
using Serenity.Services;

namespace Inide.WebServices.Persistence.Contracts
{
    public interface IRepository<T> where T: Row
    {
        public Task<ListResponse<T>> ListAsync(IDbConnection connection, ListRequest request);
        public Task<SaveResponse> CreateAsync(IUnitOfWork uow, SaveRequest<T> request);
        public Task<SaveResponse> UpdateAsync(IUnitOfWork uow, SaveRequest<T> request);
        public Task<DeleteResponse> DeleteAsync(IUnitOfWork uow, DeleteRequest request);
        public Task<RetrieveResponse<T>> RetrieveAsync(IDbConnection connection, RetrieveRequest request);
        
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Persistence.Common;
using Serenity.Data;
using Serenity.Services;

namespace Inide.WebServices.Persistence.Repository
{
    public abstract class  Repository<T> : IRepository<T> where T : Row,IIdRow,INameRow,new()
    {
        /// <summary>
        /// Crear una Entidad de Dominio
        /// </summary>
        /// <param name="uow">Unidad de Trabajo</param>
        /// <param name="request">Request de inserccion de datos</param>
        /// <returns></returns>
        public virtual async Task<SaveResponse> CreateAsync(IUnitOfWork uow, SaveRequest<T> request)
        {
            return await Task.Run(() => new MySaveHandler().Process(uow, request, SaveRequestType.Create));
        }

        /// <summary>
        /// Actualizar un entidad de dominio
        /// </summary>
        /// <param name="uow">unidad de trabajo</param>
        /// <param name="request">request con los valores actualizar</param>
        /// <returns></returns>
        public virtual async Task<SaveResponse> UpdateAsync(IUnitOfWork uow, SaveRequest<T> request)
        {
            return await Task.Run(()=>new MySaveHandler().Process(uow, request, SaveRequestType.Update));
        }

        /// <summary>
        /// Borrar una entidad de domino
        /// </summary>
        /// <param name="uow">Unidad de Trabajo</param>
        /// <param name="request">Request con el elemento a eliminar</param>
        /// <returns></returns>
        public virtual async Task<DeleteResponse> DeleteAsync(IUnitOfWork uow, DeleteRequest request)
        {
            return await Task.Run(()=>new MyDeleteHandler().Process(uow, request));
        }

        /// <summary>
        /// Recuperar un elemento
        /// </summary>
        /// <param name="connection">Coneccion de la base de datos</param>
        /// <param name="request">parametros con el item primario del elemento</param>
        /// <returns></returns>
        public virtual async Task<RetrieveResponse<T>> RetrieveAsync(IDbConnection connection, RetrieveRequest request)
        {
            return await Task.Run(()=> new MyRetrieveHandler().Process(connection, request));
        }

        /// <summary>
        /// Obtener un Listado de elementos
        /// </summary>
        /// <param name="connection">Coneccion a la base de datos</param>
        /// <param name="request">Parametros de lista de elementos a extraer</param>
        /// <returns></returns>
        public virtual async Task<ListResponse<T>> ListAsync(IDbConnection connection, ListRequest request)
        {
           return await Task.Run(()=>new MyListHandler().Process(connection, request));
        }

        /// <summary>
        /// Manejo de ciclo de Guardado
        /// </summary>
        private class MySaveHandler : SaveRequestHandler<T> {}

        /// <summary>
        /// Manejo del ciclo de borrado
        /// </summary>
        private class MyDeleteHandler : DeleteRequestHandler<T> { }

        /// <summary>
        /// Manejo del ciclo para recuperar un elemento
        /// </summary>
        private class MyRetrieveHandler : RetrieveRequestHandler<T> { }
        
        /// <summary>
        ///obtener elementos 
        /// </summary>
        private class MyListHandler : ListRequestHandler<T>
        {
            protected override void OnBeforeExecuteQuery()
            {
                base.OnBeforeExecuteQuery();
                var queryString  = this.Query.Text;
            }
        }

    }
}

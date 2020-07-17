using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Configuration;
using Serenity.Data;

namespace Inide.WebServices.Application.Factory
{
    internal static class ServiceInjectFactory
    {
        public static IUnitOfWork CreateOfWork(IDbConnection connection)
        {
            //DI Asp.net Core
            //var foo = ServiceProviderFactory.ServiceProvider.GetServices(typeof(IUnitOfWork));

            var unit = new UnitOfWork(connection);
            ///Dato que se abre por defecto la transaccion, se cierra, para que sea el repository
            /// el que maneje el ciclo de la transaccion
            unit.Commit();
            return unit;
        }

        public static IDbConnection CreateConnection()
        {
            return SqlConnections.NewByKey("Inide");
        }


    }
}

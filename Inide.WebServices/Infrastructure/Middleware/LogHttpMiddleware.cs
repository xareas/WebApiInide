using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inide.WebServices.Constants;
using Inide.WebServices.Contracts;
using Inide.WebServices.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace  Inide.WebServices.Infrastructure.MiddleWare
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly SqlServerLogWriter _writer;
        private ILogRecord _record;  


        public RequestResponseLoggingMiddleware(RequestDelegate next,
            ILoggerFactory loggerFactory, 
            ILogRecord record,
            IConfiguration configuration)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
            _configuration = configuration;
            _record = record;
            var connectionString = _configuration.GetConnectionString(AppConst.DefaultDb);
            _writer = new SqlServerLogWriter(connectionString);
        }

         public async Task Invoke(HttpContext context)
        {
            bool isFilterGet = false;
            
            if (context.Request.Method.ToUpper() == "GET")
            {
                isFilterGet = _configuration.GetValue<bool>("FilterGet");
            }

            if (IsValidPath(context.Request.Path) && !isFilterGet)
            {
                _record.IpOrigin = context.Connection.RemoteIpAddress.ToString();
                _record.Metodo = context.Request.Method;
                await FormatRequest(context.Request);

                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                   // await FormatResponse(context.Response);
                    //_logger.LogInformation(info);
                    await responseBody.CopyToAsync(originalBodyStream);
                    
                    //Escribir al log solo si se produce un error
                    //if (context.Response.StatusCode>=400)
                     _writer.WriteLog(_record);
                }
            }
            else
            {
                await _next(context);
            }

        }

        private bool IsValidPath(string path)
        {

           bool isMonitoring = _configuration.GetValue<bool>("Monitoring");
           if (!isMonitoring) return false;

            if (path.Length > 4)
            {
                var apiPath = path.Substring(1, 3).ToUpper();
                if (apiPath == "API") return true;
            }

            return false;
        }

        private async Task<string> FormatRequest(HttpRequest request)
            {
                var body = request.Body;
                request.EnableBuffering();

                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body.Position = 0;

                _record.Esquema = request.Scheme;
                _record.Host = request.Host.ToString();
                _record.Ruta = request.Path.ToString();
                _record.QueryString = request.QueryString.ToString();
                _record.Body = bodyAsText;
            
               return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";


            }


        private async Task<string> FormatResponse(HttpResponse response)
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                var text = await new StreamReader(response.Body).ReadToEndAsync();
                response.Body.Seek(0, SeekOrigin.Begin);

                _record.Response = text;
                _record.ResponseStatus = response.StatusCode;
                return $"{response.StatusCode}{text}";
            }

    }

  
}//fin

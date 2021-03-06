﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Inide.WebServices.Infrastructure.HealthChecks
{
    internal class PingHealthCheck : IHealthCheck
    {
        private string _host;
        private int _timeout;

        public PingHealthCheck(string host, int timeout)
        {
            _host = host;
            _timeout = timeout;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(_host, _timeout);
                    if (reply.Status != IPStatus.Success)
                    {
                        return HealthCheckResult.Unhealthy($"Ping chequeo status [{ reply.Status }]. Host {_host} no responde dentro de {_timeout} ms.");
                    }

                    if (reply.RoundtripTime >= _timeout)
                    {
                        return HealthCheckResult.Degraded($"Ping para {_host} toma demasiado tiempo en responder. Deberia responder en {_timeout} ms pero responde en {reply.RoundtripTime} ms.");
                    }

                    return HealthCheckResult.Healthy($"Ping al host  {_host} esta bien.");
                }
            }
            catch
            {
                return HealthCheckResult.Unhealthy($"Error al hacer ping al host: {_host}.");
            }
        }
    }
}

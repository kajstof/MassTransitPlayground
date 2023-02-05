using System;
using System.Threading;
using System.Threading.Tasks;
using Bogann.Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace MyProducer
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        public Worker(IBus bus)
        {
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new HelloMessage
                {
                    Name = $"World-Msg #{DateTime.UtcNow.Ticks}"
                }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

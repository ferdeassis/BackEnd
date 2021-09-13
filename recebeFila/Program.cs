using System;
using System.Threading.Tasks;
using MassTransit;

namespace recebeFila
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ReceiveEndpoint("fila-propostas", e =>
                {
                    e.Consumer<ConsumidorFila>();
                });
            });

            await busControl.StartAsync();
            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}

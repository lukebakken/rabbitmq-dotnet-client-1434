using RabbitMQ.Client;
using System;
using System.Runtime.CompilerServices;

namespace RabbitMQRedirectAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                ClientProvidedName = "MyClient",
                Port = 5672,
                AutomaticRecoveryEnabled = false,
                TopologyRecoveryEnabled = false,
                RequestedHeartbeat = TimeSpan.FromSeconds(10),
                RequestedChannelMax = 10000,
            };


            var connection = factory.CreateConnection();

            Console.WriteLine("CONNECTED");
            Console.ReadKey();
        }
    }
}
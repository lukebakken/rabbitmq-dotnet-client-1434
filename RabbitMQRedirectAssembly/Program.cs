using RabbitMQ.Client;
using System;

namespace RabbitMQRedirectAssembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

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

            try
            {
                var connection = factory.CreateConnection();
                connection.ConnectionShutdown += Connection_ConnectionShutdown;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex);
                Environment.Exit(1);
            }

            Console.WriteLine("CONNECTED");
            Console.ReadKey();
        }

        private static void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("ConnectionShutdown sender: {0}", sender.ToString());
            Console.WriteLine("ConnectionShutdown event args: {0}", e);
        }
    }
}
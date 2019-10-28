using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using $safeprojectname$.Contracts;

namespace $safeprojectname$
{
    public class RabbitMQServiceBus : IServiceBus
    {
        private Task ExecuteWithChannel(Action<IModel> action, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                var factory = new ConnectionFactory
                {
                    //TODO: extract to a config
                    HostName = "$ext_rabbitServer$",
                    Port = 5672,
                    Protocol = Protocols.AMQP_0_9_1,
                    UserName = "$ext_rabbitUser$",
                    Password = "$ext_rabbitPass$"
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                action(channel);
            }, cancellationToken);
        }

        public Task SendMessageAsync(string queue, object content, CancellationToken cancellationToken)
        {
            return ExecuteWithChannel(channel =>
            {
                channel.QueueDeclare(queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = JsonConvert.SerializeObject(content);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: queue,
                    basicProperties: null,
                    body: body);
            }, cancellationToken);
        }

        public Task ListenAsync<T>(string queue, Action<T> onReceived, CancellationToken cancellationToken)
        {
            return ExecuteWithChannel(channel => {
                while (!cancellationToken.IsCancellationRequested)
                {
                    channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var content = TryParse<T>(Encoding.UTF8.GetString(body));
                        if (content != null)
                        {
                            onReceived(content);
                        }

                    };
                    channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
                }
   
            }, cancellationToken);
        }

        static T TryParse<T>(string json)
        {
            //TODO: Generate and use schema to check type T and remove try catch
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default;
            }
        }

    }
}
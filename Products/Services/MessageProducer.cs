using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Products.Services;

public class MessageProducer : IMessageProducer {
	public MessageProducer() {

	}

	public void SendMessage<T>(T message) {
		// FIXME: shouldn't this be in the constructor?
		// do we establish a connection everytime 
		// we want to send a message or does 
		// the connection remain open?

		// TODO: Also, why is this a scoped service?
		var factory = new ConnectionFactory()
		{
			HostName = "127.0.0.1",
			UserName = "user",
			Password = "mypass",
			VirtualHost = "/"
		};

		var conn = factory.CreateConnection();

		// I think a model in this context is a channel
		using var channel = conn.CreateModel();

		//TODO: review settings
		channel.QueueDeclare("products", exclusive: false);
	
		var json = JsonSerializer.Serialize(message);
		var body = Encoding.UTF8.GetBytes(json);

		channel.BasicPublish(
			exchange: "", 
			routingKey: "products",
			body: body
		);
	}
}
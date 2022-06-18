using System;

namespace BuhUsl.Services
{
	public class EmailSender : IMessageSender
	{
		public void SendMessage(string recipient)
		{
			Console.WriteLine($"Подтверждение заказа отправлено на адрес: {recipient}");
		}
	}
}

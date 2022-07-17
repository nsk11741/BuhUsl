using System;

namespace BuhUsl.Services
{
	public class EmailSender : IMessageSender
	{
		public void SendMessage(string recipient)
		{
			Console.WriteLine($"Приветственное сообщение отправлено на адрес: {recipient}");
		}
	}
}

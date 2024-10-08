using MoneyWithPrism.Services.Interfaces;

namespace MoneyWithPrism.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}

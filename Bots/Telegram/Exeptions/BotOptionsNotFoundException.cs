namespace Bots.Telegram.Exeptions
{
    public class BotOptionsNotFoundException : Exception
    {
        public BotOptionsNotFoundException() : base() 
        { 

        }
        public BotOptionsNotFoundException(string message) : base(message) 
        {
        
        }

        public BotOptionsNotFoundException(string message, Exception e) : base(message, e) 
        { 

        }
    }
}

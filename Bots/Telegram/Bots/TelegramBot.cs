using Bots.Telegram.Options;
using Telegram.Bot;

namespace Bots.Telegram.Bots
{
    public class TelegramBot : ITelegramBot
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly long ChatId;

        public TelegramBot(TelegramBotOptions telegramBotOptions)
        {
            _telegramBotClient = new(telegramBotOptions.Token);
            ChatId=telegramBotOptions.ChatId;
        }

        public async Task SendMessageAsync(string message)
        {
            await _telegramBotClient.SendTextMessageAsync(ChatId, message);
        }
    }
}

using Bots.Telegram.Bots;
using Bots.Telegram.Exeptions;
using Bots.Telegram.Options; 

namespace Bots
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBot(this IServiceCollection services,IConfiguration configuration)
        {
            var options = ChekOptionsSection(configuration);
            var tgBot = new TelegramBot(options);

            services.AddSingleton<ITelegramBot>(tgBot);

            return services;
        }

        public static TelegramBotOptions ChekOptionsSection(IConfiguration configuration)
        {
            var options = configuration.GetSection(TelegramBotOptions.SECTION_NAME).Get<TelegramBotOptions>();

            if(options == null)
            {
                throw new BotOptionsNotFoundException();
            }
            else
            {
                return options;
            }
        }
    }
}


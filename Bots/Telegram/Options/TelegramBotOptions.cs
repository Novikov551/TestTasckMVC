using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bots.Telegram.Options
{
    public class TelegramBotOptions
    {
        public const string SECTION_NAME = "Telegram";

        public string Token { get; set; }

        public long ChatId { get; set; }
    }
}

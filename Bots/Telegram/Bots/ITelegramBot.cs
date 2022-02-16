using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bots.Telegram.Bots
{
    public interface ITelegramBot
    {
        Task SendMessageAsync(string message);
    }
}

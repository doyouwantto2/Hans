using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.Help
{
    public class SupportCommands:BaseCommandModule
    {
        [Command("support")]
        public async Task Support(CommandContext ctx)
        {
            string msg = "-switch\n-ban\n-get\n-pray\n-wash";
            await ctx.Channel.SendMessageAsync(msg);
        }
    }
}

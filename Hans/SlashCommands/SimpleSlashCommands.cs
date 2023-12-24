using DSharpPlus.Net.Models;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.SlashCommands
{
    public class SimpleSlashCommands : ApplicationCommandModule
    {
        [SlashCommand("First", "Try it")]
        public async Task FirstCommand(InteractionContext ctx,
            [Choice("Root1","null")]
                [Option("Chil1","Title1")] string A1,
                [Option("Chil2", "Title2")] string A2,
                [Option("Chil3", "Title3")] string A3,
            [Choice("Root2","null")]
                [Option("Chil1","Title1")] string B1,
                [Option("Chil2", "Title2")] string B2,
                [Option("Chil3", "Title3")] string B3
        )
        {
            await ctx.CreateResponseAsync("Hi");
        }
    }
}

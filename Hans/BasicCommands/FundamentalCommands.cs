using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.BasicCommands
{
    public class FundamentalCommands : BaseCommandModule
    {
        [Command("switch")]
        public async Task Switch(CommandContext ctx)
        {
            var Button1 = new DiscordButtonComponent(DSharpPlus.ButtonStyle.Danger, "1", "Anyway");

            DiscordMessageBuilder Message = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                {
                    Title = "Tile",
                    Description = "Hi",
                    Color = DiscordColor.Azure
                }).AddComponents(Button1);

            await ctx.Channel.SendMessageAsync(Message);
        }

        [Command("ban")]
        [RequirePermissions(Permissions.BanMembers)]
        [RequireBotPermissions(Permissions.BanMembers)]
        [RequireUserPermissions(Permissions.Administrator)]
        public async Task ban(CommandContext ctx, DiscordMember member, [RemainingText]string reason)
        {
            await member.BanAsync(1, reason);
            await ctx.Channel.SendMessageAsync("Test ban command");
        }

        [Command("get")]
        public async Task GetRole(CommandContext ctx, DiscordMember member)
        {
            var Message = await ctx.Channel.SendMessageAsync("Get role!");
            var role = ctx.Guild.GetRole(1188439085715574795);
            await member.GrantRoleAsync(role);
            await ctx.Channel.SendMessageAsync("You have been approved");
        }
    }
}

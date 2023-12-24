

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using Hans.BasicCommands;
using Hans.SlashCommands;

namespace Hans
{
    class Program
    {
        static DiscordClient _Client { get; set; }
        static CommandsNextExtension _Command { get;set; }
        public async static Task Main(string[] args)
        {
            var clientConfig = new DiscordConfiguration()
            {
                Token = ConfigOnly.Token,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents,
                TokenType = TokenType.Bot
            };

            var commandConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            };

            _Client = new DiscordClient(clientConfig);
            _Client.Ready += OnReady;
            _Client.ComponentInteractionCreated += ButtonReacted;
            

            var interactivityConfig = new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromSeconds(15)
            };
            _Client.UseInteractivity(interactivityConfig);

            _Command = _Client.UseCommandsNext(commandConfig);
            _Command.RegisterCommands<FundamentalCommands>();

            var SlashCommand = _Client.UseSlashCommands();
            SlashCommand.RegisterCommands<SimpleSlashCommands>(944959463310385162);

            await _Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static async Task ButtonReacted(DiscordClient sender, DSharpPlus.EventArgs.ComponentInteractionCreateEventArgs args)
        {
            if(args.Interaction.Data.CustomId == "1")
            {
                await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DSharpPlus.Entities.DiscordInteractionResponseBuilder()
                    .WithContent("You pressed button 1"));
            }
        }

        private static Task OnReady(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            Console.WriteLine($"{sender.CurrentUser} is connected");
            return Task.CompletedTask;
        }
    }
}
using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace NosCompanion
{
    class Program
    {
        private DiscordSocketClient _client;
        private string _token;
        private CommandHandler _commandHandler;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult()
            ;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _commandHandler = new CommandHandler(_client, new Discord.Commands.CommandService());
            _token = "";

            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
           
            await _commandHandler.InstallCommandsAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

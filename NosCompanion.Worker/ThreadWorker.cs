using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace NosCompanion.Worker
{
    public class ThreadWorker
    {
        private IConfiguration _configuration;
        private DiscordSocketClient _client;
        private string _token;
        private CommandHandler _commandHandler;

        public async Task StartAsync()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("nos-companion.json")
                .Build()
                ;

            _client = new DiscordSocketClient();
            _commandHandler = new CommandHandler(_client, new Discord.Commands.CommandService());
            _token = _configuration.GetValue<string>("token");

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            await _commandHandler.InstallCommandsAsync();
            await Task.Delay(-1);
        }
    }
}

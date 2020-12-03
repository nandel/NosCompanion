using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace NosCompanion
{
    public class ThreadWorker
    {
        private readonly string _token;

        private DiscordSocketClient _client;
        private CommandHandler _commandHandler;

        public ThreadWorker(string token)
        {
            _token = token;
        }

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            _commandHandler = new CommandHandler(_client, new Discord.Commands.CommandService());

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            await _commandHandler.InstallCommandsAsync();
            await Task.Delay(-1);
        }
    }
}

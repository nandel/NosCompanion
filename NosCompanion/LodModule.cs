using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace NosCompanion
{
    public class LodModule : ModuleBase<SocketCommandContext>
    {
        [Command("lost")]
        [Summary("Easter egg do steel")]
        public Task LostAsync()
            => ReplyAsync("Olá steel, Lost foi um seriado dos anos 2000 que teve seu ultimo episódio em 23 de maio de 2010.");

        [Command("lod")]
        [Summary("Saiba quando é a proxima lod")]
        public Task LodAsync()
        {
            var state = DateTime.UtcNow.Hour % 3;       
            
            switch (state)
            {
                case 0:
                    ReplyAsync($"A lod acabou de terminar, a proxima abre em {60 - DateTime.Now.Minute} minutos.");
                    break;

                case 1:
                    var chanel = DateTime.UtcNow.Hour % 8 + 1 % 5;
                    ReplyAsync($"A lod encontra-se aberta e o DH irá aparecer em {60 - DateTime.Now.Minute} minutos no chanel {chanel}.");
                    break;

                case 2:
                    ReplyAsync($"A lod ta rolando com o DH nesse momento, espere a proxima em 1hora e {60 - DateTime.Now.Minute}minutos.");
                    break;
            }

            return Task.CompletedTask;
        }
    }
}

﻿using Discord;
using Discord.Commands;
using System;
using System.Linq;
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
            var state = GetLodState(DateTime.UtcNow);
            
            switch (state)
            {
                case LodState.Closed:
                    return ReplyAsync($"A lod acabou de terminar, a proxima abre em {60 - DateTime.Now.Minute} minutos.");

                case LodState.Open:
                    var chanel = GetLodChanel(DateTime.UtcNow);
                    return ReplyAsync($"A lod encontra-se aberta e o DH irá aparecer em {60 - DateTime.Now.Minute} minutos no chanel {chanel}.");

                case LodState.OnGoing:
                    return ReplyAsync($"A lod ta rolando com o DH nesse momento, espere a proxima em 1hora e {60 - DateTime.Now.Minute}minutos.");
            }

            return Task.CompletedTask;
        }

        public static LodState GetLodState(DateTime dateTime)
        {
            var serverTime = TimeZoneInfo.ConvertTime(
                dateTime,
                TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")
            );

            return (LodState) (serverTime.Hour % 3);
        }

        public static int GetLodChanel(DateTime dateTime)
        {
            var serverTime = TimeZoneInfo.ConvertTime(
                dateTime,
                TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")
            );

            if (serverTime.Hour < 15)
            {
                return (serverTime.Hour / 3) + 1;
            }

            if (serverTime.Hour >= 15)
            {
                return (serverTime.Hour / 3) - 3;
            }

            return 1;
        }
    }

    public enum LodState : int
    {
        Open = 0,
        OnGoing = 1,
        Closed = 2,
    }
}

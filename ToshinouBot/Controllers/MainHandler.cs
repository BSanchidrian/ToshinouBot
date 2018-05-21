using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using System.Linq;

namespace ToshinouBot.Controllers
{
    class MainHandler
    {
        public DiscordSocketClient Client;

        public MainHandler(DiscordSocketClient Discord) {
            Discord.Ready += OnReadyUpdateBrahDuh;
            Discord.GuildMemberUpdated += OnBrahDuhUpdated;
            Client = Discord;
        }

        private async Task OnReadyUpdateBrahDuh() {
            SocketGuild guild = Client.GetGuild(434604419255107586);
            SocketRole role = guild.GetRole(435902767358410762);
            SocketGuildUser user = guild.GetUser(427905551763111950);

            if (!user.Roles.Contains(role)) {
                Console.WriteLine("Updated BruhDuh");
                await user.AddRoleAsync(role);
            }
        }

        private async Task OnBrahDuhUpdated(SocketGuildUser before, SocketGuildUser after)
        {
            if (after.Id == 427905551763111950)
            {
                SocketGuild guild = Client.GetGuild(434604419255107586);
                SocketRole role = guild.GetRole(435902767358410762);

                if (!after.Roles.Contains(role))
                {
                    Console.WriteLine("Updated BruhDuh");
                    await after.AddRoleAsync(role);
                }
            }
        }
    }
}

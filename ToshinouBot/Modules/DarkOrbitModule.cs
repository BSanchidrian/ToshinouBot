using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToshinouBot.Services;

namespace ToshinouBot.Modules
{
    public class DarkOrbitModule : ModuleBase<SocketCommandContext>
    {
        readonly DarkOrbitService darkOrbitService;

        public DarkOrbitModule(DarkOrbitService darkOrbitService)
        {
            this.darkOrbitService = darkOrbitService;
        }

        [Command("checkUpdate", RunMode=RunMode.Async)]
        public async Task CheckUpdate()
        {
            var updated = await this.darkOrbitService.CheckUpdateAsync();
            await this.ReplyAsync($"{updated}");
        }
    }
}

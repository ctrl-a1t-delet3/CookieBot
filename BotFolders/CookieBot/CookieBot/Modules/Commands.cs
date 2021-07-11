using Discord.Commands;
using System.Threading.Tasks;
using Discord;

namespace CookieBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        public Commands()
        {
            var File = new File();
            var FileWriter = new FileWriter();
        }

        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong");
        }

        [Command("changeprefix")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "Insufficient permissions")]
        public async Task ChangePrefix(string newPrefix = null)
        {
            if (newPrefix == null)
            {
                await ReplyAsync("Please enter a prefix to change to!");
            }
            if (newPrefix.Length > 1)
            {
                await ReplyAsync("Please enter a singular character to change the prefix to! (ex. !, ?, ., etc.");
            }
            else
            {
                Startup.prefix = newPrefix;
                await ReplyAsync("Change sucessful!");
            }
        }
    }
}

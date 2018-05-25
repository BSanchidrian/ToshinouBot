using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToshinouBot.Services
{
    public class DarkOrbitService
    {
        private string Md5Folder = "md5Checks";

        public async Task<bool> CheckUpdateAsync()
        {
            using (WebClient webClient = new WebClient())
            {
                var filename = $"main.swf";
                await webClient.DownloadFileTaskAsync("https://darkorbit.com/spacemap/main.swf", filename);

                var md5 = await this.GetMd5(filename);
                File.Delete(filename);

                var file = Path.Combine(this.Md5Folder, md5);
                var directory = Path.GetDirectoryName(file);
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                if (File.Exists(file))
                    return false;

                File.Create(file);
                return true;
            }
        }

        private async Task<string> GetMd5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                var stream = await File.ReadAllBytesAsync(filename);
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}

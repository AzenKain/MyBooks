using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Services
{
    public class DownloadService
    {
        public async Task DownloadAsync(
            string url,
            string output,
            Action<long, long, double> progress)
        {
            using var client = new HttpClient();
            using var res = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            res.EnsureSuccessStatusCode();

            var total = res.Content.Headers.ContentLength ?? 0;
            using var stream = await res.Content.ReadAsStreamAsync();
            using var fs = new FileStream(output, FileMode.Create, FileAccess.Write);

            var buffer = new byte[8192];
            long readTotal = 0;
            var sw = Stopwatch.StartNew();

            int read;
            while ((read = await stream.ReadAsync(buffer)) > 0)
            {
                await fs.WriteAsync(buffer.AsMemory(0, read));
                readTotal += read;

                double speed = readTotal / 1024d / sw.Elapsed.TotalSeconds;
                progress?.Invoke(readTotal, total, speed);
            }
        }
    }
}

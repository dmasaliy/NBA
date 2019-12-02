using System.Drawing;
using System.IO;

using System.Net;

using System.Threading.Tasks;

namespace NBA.Infrastructure
{
    static class ImageUtil
    {
        public static Task<Image> FromURL(string url)
        {
            return Task.Run(() =>
            {
                using (var nb = new MemoryStream(new WebClient().DownloadData(url)))
                {
                    return Image.FromStream(nb);
                }
            });
        }
    }
}

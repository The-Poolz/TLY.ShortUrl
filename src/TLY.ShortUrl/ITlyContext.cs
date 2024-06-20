using System.Threading.Tasks;

namespace TLY.ShortUrl
{
    public interface ITlyContext
    {
        public Task<ShortenedLinkResponse> GetShortUrlAsync(
            string longUrl,
            string description,
            string domain = "https://t.ly",
            bool publicStats = true
        );
    }
}

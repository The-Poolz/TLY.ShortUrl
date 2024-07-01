using System.Threading.Tasks;

namespace TLY.ShortUrl
{
    public interface ITlyContext
    {
        public Task<ShortenedLinkResponse> CreateShortUrlAsync(
            string longUrl,
            string description,
            string domain = "https://t.ly",
            bool publicStats = true
        );

        public Task<ShortenedLinkResponse> SearchShortUrlAsync(
            string description
        );
    }
}

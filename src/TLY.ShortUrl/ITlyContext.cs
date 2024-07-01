using System.Threading.Tasks;
using TLY.ShortUrl.Responses;

namespace TLY.ShortUrl
{
    public interface ITlyContext
    {
        public Task<CreateShortUrlResponse> CreateShortUrlAsync(
            string longUrl,
            string description,
            string domain = "https://t.ly",
            bool publicStats = true
        );

        public Task<SearchShortUrlResponse> SearchShortUrlAsync(
            string description
        );
    }
}

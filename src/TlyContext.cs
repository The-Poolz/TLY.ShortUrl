using Flurl.Http;

namespace TLY.ShortUrl
{
    public class TlyContext
    {
        private readonly string _apiKey;

        public TlyContext(string apiKey) => _apiKey = apiKey;

        public async Task<ShortenedLinkResponse> GetShortUrlAsync(string longUrl, string description, string domain = "https://t.ly", bool publicStats = true) =>
            await GetResponse(await GetFlurlResponse(longUrl, description, domain, publicStats));

        public virtual Task<ShortenedLinkResponse> GetResponse(IFlurlResponse? response) =>
            response == null ? throw new Exception() : response.GetJsonAsync<ShortenedLinkResponse>();

        public virtual Task<IFlurlResponse?> GetFlurlResponse(string longUrl, string description, string domain, bool publicStats) =>
            "https://t.ly/api/v1/link/shorten"
                .WithHeader("Authorization", $"Bearer {_apiKey}")
                .WithHeader("Content-Type", "application/json")
                .WithHeader("Accept", "application/json")
                .PostJsonAsync(new
                {
                    long_url = longUrl,
                    domain,
                    description,
                    public_stats = publicStats
                });
    }
}
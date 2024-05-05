using Flurl.Http;

namespace TLY.ShortUrl;

public class TlyContext(string apiKey)
{
    public async Task<ShortenedLinkResponse> GetShortUrlAsync(string LongUrl, string Description, string Domain = "https://t.ly", bool PublicStats = true) =>
        await GetResponse(await GetFlurlResponse(LongUrl, Description, Domain, PublicStats));

    public virtual Task<ShortenedLinkResponse> GetResponse(IFlurlResponse? response) =>
        response == null ? throw new Exception() : response.GetJsonAsync<ShortenedLinkResponse>();

    public virtual Task<IFlurlResponse?> GetFlurlResponse(string LongUrl, string Description, string Domain, bool PublicStats) =>
        "https://t.ly/api/v1/link/shorten"
            .WithHeader("Authorization", $"Bearer {apiKey}")
            .WithHeader("Content-Type", "application/json")
            .WithHeader("Accept", "application/json")
            .PostJsonAsync(new
            {
                long_url = LongUrl,
                domain = Domain,
                description = Description,
                public_stats = PublicStats
            });
}

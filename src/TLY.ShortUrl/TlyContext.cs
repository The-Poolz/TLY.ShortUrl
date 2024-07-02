using Flurl;
using System;
using Flurl.Http;
using TLY.ShortUrl.Settings;
using System.Threading.Tasks;
using TLY.ShortUrl.Responses;

namespace TLY.ShortUrl
{
    public class TlyContext : ITlyContext
    {
        private readonly string _apiKey;
        private readonly IApiEndpoints _endpointsUrls;

        public TlyContext(string apiKey)
            : this(apiKey, new DefaultApiEndpoints())
        { }

        public TlyContext(string apiKey, IApiEndpoints endpointsUrls)
        {
            _apiKey = apiKey;
            _endpointsUrls = endpointsUrls;
        }

        public async Task<SearchShortUrlResponse> SearchShortUrlAsync(
            string description
        )
        {
            var flurlResponse = await GetRequestAsync(
                url: _endpointsUrls.ListShortLinks.AppendQueryParam("search", description)
            );

            return await ParseResponseAsync<SearchShortUrlResponse>(flurlResponse);
        }

        public async Task<CreateShortUrlResponse> CreateShortUrlAsync(
            string longUrl,
            string description,
            string domain = "https://t.ly",
            bool publicStats = true
        )
        {
            var body = new
            {
                long_url = longUrl,
                domain,
                description,
                public_stats = publicStats
            };

            var flurlResponse = await PostRequestAsync(_endpointsUrls.CreateShortLink, body);

            return await ParseResponseAsync<CreateShortUrlResponse>(flurlResponse);
        }

        internal async Task<IFlurlResponse?> GetRequestAsync(string url)
        {
            return await RequestWithAuthorization(url)
                .GetAsync();
        }

        internal async Task<IFlurlResponse?> PostRequestAsync(string url, object body)
        {
            return await RequestWithAuthorization(url)
                .WithHeader("Content-Type", "application/json")
                .WithHeader("Accept", "application/json")
                .PostJsonAsync(body);
        }

        internal IFlurlRequest RequestWithAuthorization(string url)
        {
            return url.WithHeader("Authorization", $"Bearer {_apiKey}");
        }

        internal static async Task<TResponse> ParseResponseAsync<TResponse>(IFlurlResponse? flurlResponse)
        {
            return flurlResponse == null
                ? throw new InvalidOperationException("Failed to receive a valid response from the external service.")
                : await flurlResponse.GetJsonAsync<TResponse>();
        }
    }
}
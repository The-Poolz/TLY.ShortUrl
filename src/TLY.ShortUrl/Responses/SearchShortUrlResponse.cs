using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TLY.ShortUrl.Responses
{
    public class SearchShortUrlResponse
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("data")]
        public IEnumerable<SearchShortUrlResponse> Data { get; set; } = Enumerable.Empty<SearchShortUrlResponse>();
    }
}

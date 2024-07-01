using System;
using System.Text.Json.Serialization;

namespace TLY.ShortUrl.Responses
{
    public class CreateShortUrlResponse
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("long_url")]
        public string LongUrl { get; set; } = string.Empty;

        [JsonPropertyName("short_url")]
        public string ShortUrl { get; set; } = string.Empty;

        [JsonPropertyName("domain")]
        public string Domain { get; set; } = string.Empty;

        [JsonPropertyName("short_id")]
        public string ShortId { get; set; } = string.Empty;

        [JsonPropertyName("expire_at_datetime")]
        public DateTime? ExpireAtDatetime { get; set; }

        [JsonPropertyName("expire_at_views")]
        public int? ExpireAtViews { get; set; }

        [JsonPropertyName("public_stats")]
        public bool PublicStats { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}

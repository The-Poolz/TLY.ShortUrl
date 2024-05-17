using System.Text.Json.Serialization;

namespace TLY.ShortUrl
{
    public class ShortenedLinkResponse
    {
        [JsonPropertyName("short_url")]
        public string ShortUrl { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("long_url")]
        public string LongUrl { get; set; } = null!;

        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("short_id")]
        public string ShortId { get; set; } = null!;

        [JsonPropertyName("expire_at_views")]
        public int? ExpireAtViews { get; set; }

        [JsonPropertyName("expire_at_datetime")]
        public DateTime? ExpireAtDatetime { get; set; }

        [JsonPropertyName("public_stats")]
        public bool PublicStats { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
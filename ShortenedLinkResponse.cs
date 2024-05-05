namespace TLY.ShortUrl;

public class ShortenedLinkResponse
{
    public string short_url { get; set; }
    public string description { get; set; }
    public string long_url { get; set; }
    public string domain { get; set; }
    public string short_id { get; set; }
    public int? expire_at_views { get; set; }
    public DateTime? expire_at_datetime { get; set; }
    public bool public_stats { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

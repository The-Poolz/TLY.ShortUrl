namespace TLY.ShortUrl.Settings
{
    public interface IApiEndpoints
    {
        public string CreateShortLink { get; }
        public string ListShortLinks { get; }
    }
}

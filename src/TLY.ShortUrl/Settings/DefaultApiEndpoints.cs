namespace TLY.ShortUrl.Settings
{
    public class DefaultApiEndpoints : IApiEndpoints
    {
        public string CreateShortLink => "https://api.t.ly/api/v1/link/shorten";
        public string ListShortLinks => "https://api.t.ly/api/v1/link/list";
    }
}

namespace TLY.ShortUrl.Tests.MockResponses;

internal static class MockCreateShortUrl
{
    internal static string Response => @"
    {
        ""description"": ""TEST DESCRIPTION #1"",
        ""long_url"": ""https://www.google.com"",
        ""short_url"": ""https://t.ly/vVRMv"",
        ""domain"": ""https://t.ly/"",
        ""short_id"": ""vVRMv"",
        ""expire_at_datetime"": null,
        ""expire_at_views"": null,
        ""public_stats"": true,
        ""meta"": {
            ""smart_urls"": []
        },
        ""created_at"": ""2024-07-01T16:20:27.000000Z"",
        ""updated_at"": ""2024-07-01T16:20:27.000000Z"",
        ""has_password"": false
    }";
}
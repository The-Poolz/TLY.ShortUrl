namespace TLY.ShortUrl.Tests.MockResponses;

internal static class MockSearchShortUrl
{
    internal static string Response => @"
    {
        ""current_page"": 1,
        ""data"": [
            {
                ""description"": ""TEST DESCRIPTION #1"",
                ""long_url"": ""https://www.google.com"",
                ""short_url"": ""https://t.ly/vVRMv"",
                ""domain"": ""https://t.ly/"",
                ""short_id"": ""vVRMv"",
                ""user_id"": 123,
                ""team_id"": 123,
                ""domain_id"": null,
                ""safe_link"": null,
                ""expire_at_datetime"": null,
                ""expire_at_views"": null,
                ""public_stats"": true,
                ""meta"": {
                    ""smart_urls"": []
                },
                ""created_at"": ""2024-07-01T16:20:27.000000Z"",
                ""updated_at"": ""2024-07-01T16:20:27.000000Z"",
                ""has_password"": false,
                ""short_stats"": null,
                ""user"": {
                    ""id"": 123,
                    ""name"": ""UserName"",
                    ""email"": ""username@google.com"",
                    ""photo_url"": ""https://www.gravatar.com/avatar/123.jpg?s=200&d=mm"",
                    ""current_team_id"": 123,
                    ""created_at"": ""2024-07-01T16:20:27.000000Z"",
                    ""updated_at"": ""2024-07-01T16:20:27.000000Z""
                },
                ""qr_code"": null,
                ""tags"": [],
                ""pixels"": []
            },
            {
                ""description"": ""TEST DESCRIPTION #1"",
                ""long_url"": ""https://www.google.com"",
                ""short_url"": ""https://t.ly/vVRMv"",
                ""domain"": ""https://t.ly/"",
                ""short_id"": ""vVRMv"",
                ""user_id"": 123,
                ""team_id"": 123,
                ""domain_id"": null,
                ""safe_link"": null,
                ""expire_at_datetime"": null,
                ""expire_at_views"": null,
                ""public_stats"": true,
                ""meta"": {
                    ""smart_urls"": []
                },
                ""created_at"": ""2024-07-01T16:20:27.000000Z"",
                ""updated_at"": ""2024-07-01T16:20:27.000000Z"",
                ""has_password"": false,
                ""short_stats"": null,
                ""user"": {
                    ""id"": 123,
                    ""name"": ""UserName"",
                    ""email"": ""username@google.com"",
                    ""photo_url"": ""https://www.gravatar.com/avatar/123.jpg?s=200&d=mm"",
                    ""current_team_id"": 123,
                    ""created_at"": ""2024-07-01T16:20:27.000000Z"",
                    ""updated_at"": ""2024-07-01T16:20:27.000000Z""
                },
                ""qr_code"": null,
                ""tags"": [],
                ""pixels"": []
            }
        ],
        ""first_page_url"": ""https://api.t.ly/api/v1/link/list?page=1"",
        ""from"": 1,
        ""last_page"": 1,
        ""last_page_url"": ""https://api.t.ly/api/v1/link/list?page=1"",
        ""links"": [
            {
                ""url"": null,
                ""label"": ""&laquo; Previous"",
                ""active"": false
            },
            {
                ""url"": ""https://api.t.ly/api/v1/link/list?page=1"",
                ""label"": ""1"",
                ""active"": true
            },
            {
                ""url"": null,
                ""label"": ""Next &raquo;"",
                ""active"": false
            }
        ],
        ""next_page_url"": null,
        ""path"": ""https://api.t.ly/api/v1/link/list"",
        ""per_page"": 15,
        ""prev_page_url"": null,
        ""to"": 2,
        ""total"": 2
    }";
}
# TLY.ShortUrl

A .NET library for creating shortened URLs using the T.ly URL shortening service.

## Getting Started

To use TLY.ShortUrl, you'll need an API key from T.ly. You can obtain one by registering at their [official website](https://t.ly).

## Installation

Install the package via NuGet:

```bash
dotnet add package TLY.ShortUrl
```

## Usage

Here's how to use the library to shorten a URL:
```csharp
using TLY.ShortUrl;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY"; // Replace with your actual TLY API key.
        var tlyContext = new TlyContext(apiKey);

        string longUrl = "http://example.com/";
        string description = "Social Media Link";

        var shortenedLink = await tlyContext.GetShortUrlAsync(longUrl, description);
        Console.WriteLine($"Shortened URL: {shortenedLink.short_url}");
    }
}
```

## Classes and Methods

### `TlyContext`

- **`Task<ShortenedLinkResponse> GetShortUrlAsync(string longUrl, string description, string domain = "https://t.ly", bool publicStats = true)`**  
  Initiates a request to shorten a URL and returns a `ShortenedLinkResponse` object containing details about the shortened URL.

### `ShortenedLinkResponse`

- **Properties:**
  - `string short_url` - The shortened URL.
  - `string description` - A description of the shortened URL.
  - `string long_url` - The original URL before shortening.
  - `string domain` - The domain used for the shortened URL.
  - `string short_id` - A unique identifier for the shortened URL.
  - `int? expire_at_views` - The number of views after which the link will expire.
  - `DateTime? expire_at_datetime` - The date and time when the link will expire.
  - `bool public_stats` - Indicates whether the statistics of the shortened URL are public.
  - `DateTime created_at` - The date and time when the shortened URL was created.
  - `DateTime updated_at` - The date and time when the shortened URL was last updated.


## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request.

## License

This project is licensed under the unlicense - see the LICENSE file for details.

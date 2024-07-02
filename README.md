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

### Initialization

To use the `TlyContext`, you need an API key from TLY. You can instantiate the `TlyContext` with the API key as shown below:

```csharp
using TLY.ShortUrl;

string apiKey = "your_api_key_here";
var context = new TlyContext(apiKey);
```

### Creating a Short URL

You can create a short URL by calling the `CreateShortUrlAsync` method:

```csharp
var response = await context.CreateShortUrlAsync(
    longUrl: "https://example.com",
    description: "Example URL",
    domain: "https://t.ly",
    publicStats: true
);

Console.WriteLine($"Short URL: {response.ShortUrl}");
```

### Searching for Short URLs

You can search for existing short URLs by description using the `SearchShortUrlAsync` method:

```csharp
var response = await context.SearchShortUrlAsync("Example URL");

foreach (var shortUrl in response.Data)
{
    Console.WriteLine($"Found Short URL: {shortUrl.ShortUrl}");
}
```

### Custom API Endpoints

If you need to use custom API endpoints, you can implement the `IApiEndpoints` interface and pass it to the `TlyContext` constructor:

```csharp
using TLY.ShortUrl.Settings;

public class CustomApiEndpoints : IApiEndpoints
{
    public string CreateShortLink => "https://custom-api.t.ly/v1/link/shorten";
    public string ListShortLinks => "https://custom-api.t.ly/v1/link/list";
}

var customEndpoints = new CustomApiEndpoints();
var context = new TlyContext(apiKey, customEndpoints);
```


## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request.

## License

This project is licensed under the unlicense - see the LICENSE file for details.

using Flurl.Http;
using System.Net;
using FluentAssertions;
using System.Globalization;
using TLY.ShortUrl.Responses;
using TLY.ShortUrl.Tests.MockResponses;

namespace TLY.ShortUrl.Tests;

public class TlyContextTests
{
    public class ParseResponseAsync
    {
        [Fact]
        internal async Task WhenFlurlResponseNotNull_ShouldParseResponseToModel_ForCreateShortUrlResponse()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockCreateShortUrl.Response)
            };
            var flurlResponse = new FlurlResponse(new FlurlCall
            {
                HttpResponseMessage = mockResponse,
                Request = new FlurlRequest()
            });

            var result = await TlyContext.ParseResponseAsync<CreateShortUrlResponse>(flurlResponse);

            result.Should().NotBeNull();
            result.Description.Should().Be("TEST DESCRIPTION #1");
            result.LongUrl.Should().Be("https://www.google.com");
            result.ShortUrl.Should().Be("https://t.ly/hNie_");
            result.Domain.Should().Be("https://t.ly/");
            result.ShortId.Should().Be("hNie_");
            result.ExpireAtDatetime.Should().BeNull();
            result.ExpireAtViews.Should().BeNull();
            result.PublicStats.Should().BeTrue();
            result.CreatedAt.Should().Be(DateTime.Parse("2024-07-02T05:18:25.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
            result.UpdatedAt.Should().Be(DateTime.Parse("2024-07-02T05:18:25.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
        }

        [Fact]
        internal async Task WhenFlurlResponseNotNull_ShouldParseResponseToModel_ForSearchShortUrlResponse()
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockSearchShortUrl.Response)
            };
            var flurlResponse = new FlurlResponse(new FlurlCall
            {
                HttpResponseMessage = mockResponse,
                Request = new FlurlRequest()
            });

            var result = await TlyContext.ParseResponseAsync<SearchShortUrlResponse>(flurlResponse);

            result.Should().NotBeNull();
            result.CurrentPage.Should().Be(1);
            result.Data.Should().HaveCount(2);

            var firstItem = result.Data.First();
            firstItem.Description.Should().Be("TEST DESCRIPTION #1");
            firstItem.LongUrl.Should().Be("https://www.google.com");
            firstItem.ShortUrl.Should().Be("https://t.ly/vVRMv");
            firstItem.Domain.Should().Be("https://t.ly/");
            firstItem.ShortId.Should().Be("vVRMv");
            firstItem.ExpireAtDatetime.Should().BeNull();
            firstItem.ExpireAtViews.Should().BeNull();
            firstItem.PublicStats.Should().BeTrue();
            firstItem.CreatedAt.Should().Be(DateTime.Parse("2024-07-01T16:20:27.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
            firstItem.UpdatedAt.Should().Be(DateTime.Parse("2024-07-01T16:20:27.000000Z", new DateTimeFormatInfo()).ToUniversalTime());

            var secondItem = result.Data.Last();
            secondItem.Description.Should().Be("TEST DESCRIPTION #1");
            secondItem.LongUrl.Should().Be("https://www.google.com");
            secondItem.ShortUrl.Should().Be("https://t.ly/XGxcx");
            secondItem.Domain.Should().Be("https://t.ly/");
            secondItem.ShortId.Should().Be("XGxcx");
            secondItem.ExpireAtDatetime.Should().BeNull();
            secondItem.ExpireAtViews.Should().BeNull();
            secondItem.PublicStats.Should().BeTrue();
            secondItem.CreatedAt.Should().Be(DateTime.Parse("2024-07-01T13:40:09.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
            secondItem.UpdatedAt.Should().Be(DateTime.Parse("2024-07-01T13:40:09.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
        }

        [Fact]
        internal async Task ShouldThrowInvalidOperationException_WhenFlurlResponseIsNull()
        {
            Func<Task> testCode = async () => await TlyContext.ParseResponseAsync<CreateShortUrlResponse>(null);

            await testCode.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Failed to receive a valid response from the external service.");
        }

        [Fact]
        internal async Task ShouldThrowFlurlParsingException_WhenFlurlResponseIsInvalid()
        {
            var invalidJsonResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Invalid JSON")
            };
            var flurlResponse = new FlurlResponse(new FlurlCall
            {
                HttpResponseMessage = invalidJsonResponse,
                HttpRequestMessage = new HttpRequestMessage(),
                Request = new FlurlRequest(),
                Client = new FlurlClient()
            });

            var testCode = async () => await TlyContext.ParseResponseAsync<CreateShortUrlResponse>(flurlResponse);

            await testCode.Should().ThrowAsync<FlurlParsingException>();
        }
    }
}
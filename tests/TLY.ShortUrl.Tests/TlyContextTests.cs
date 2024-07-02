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
            AssertsForCreateShortUrlResponse(result);
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
            AssertsForCreateShortUrlResponse(firstItem);

            var secondItem = result.Data.Last();
            AssertsForCreateShortUrlResponse(secondItem);
        }

        private static void AssertsForCreateShortUrlResponse(CreateShortUrlResponse objectBeingChecked)
        {
            objectBeingChecked.Description.Should().Be("TEST DESCRIPTION #1");
            objectBeingChecked.LongUrl.Should().Be("https://www.google.com");
            objectBeingChecked.ShortUrl.Should().Be("https://t.ly/vVRMv");
            objectBeingChecked.Domain.Should().Be("https://t.ly/");
            objectBeingChecked.ShortId.Should().Be("vVRMv");
            objectBeingChecked.ExpireAtDatetime.Should().BeNull();
            objectBeingChecked.ExpireAtViews.Should().BeNull();
            objectBeingChecked.PublicStats.Should().BeTrue();
            objectBeingChecked.CreatedAt.Should().Be(DateTime.Parse("2024-07-01T16:20:27.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
            objectBeingChecked.UpdatedAt.Should().Be(DateTime.Parse("2024-07-01T16:20:27.000000Z", new DateTimeFormatInfo()).ToUniversalTime());
        }
    }
}
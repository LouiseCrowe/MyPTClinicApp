using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MyPTClinicApp.Shared;
using RichardSzalay.MockHttp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

public static class MockHttpClientBunitHelpers
{
    public static MockHttpMessageHandler AddMockHttpClient(this TestServiceProvider services)
    {
        var mockHttpHandler = new MockHttpMessageHandler();
        var httpClient = mockHttpHandler.ToHttpClient();
        httpClient.BaseAddress = new Uri("http://localhost");
        services.AddSingleton<HttpClient>(httpClient);
        return mockHttpHandler;
    }

    //var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
    //mockHttpMessageHandler.Protected()
    //.Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
    //.ReturnsAsync(new HttpResponseMessage
    //{
    //    StatusCode = HttpStatusCode.OK,
    //    Content = new StringContent("{'name':thecodebuzz,'city':'USA'}"),
    //});

//Just for reviewing from https://www.codeguru.co.in/2020/05/easily-mock-htppclient-in-c-using-moq.html
//public static Mock<HttpMessageHandler> GetFakeHttpClient()
//{

//    // ARRANGE
//    var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
//    handlerMock
//       .Protected()
//            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//           .ReturnsAsync(new HttpResponseMessage()
//           {
//               StatusCode = HttpStatusCode.OK,
//               Content = new StringContent("[{'id':1,'name':'Leanne Graham','email':'example@test.com'}]"),
//           }).Verifiable();
//    return handlerMock;

//}

//public class TestHelper
//{

//    public static Mock<HttpMessageHandler> GetFakeHttpClient()
//    {

//        // ARRANGE
//        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
//        handlerMock
//           .Protected()
//                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//               .ReturnsAsync(new HttpResponseMessage()
//               {
//                   StatusCode = HttpStatusCode.OK,
//                   Content = new StringContent("[{'id':1,'name':'Leanne Graham','email':'example@test.com'}]"),
//               }).Verifiable();
//        return handlerMock;

//    }
//}

//public class RestClient
//{
//    private readonly HttpClient _httpClient;
//    public RestClient(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
//    }
//    public async Task<HttpResponseMessage> GetSomethingRemoteAsync(string url)
//    {
//        var result = await _httpClient.GetAsync("users");
//        return result;
//    }
//}




//public class RestClientTest
//{


//    [Fact]
//    public async Task It_Should_Return_Response_If_Input_Is_Valid()
//    {
//        var handlerMock = TestHelper.GetFakeHttpClient();
//        var httpClient = new HttpClient(handlerMock.Object)
//        {
//            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
//        };

//        var restClient = new RestClient(httpClient);

//        // ACT
//        var result = await restClient
//           .GetSomethingRemoteAsync("users");

//        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
//        Assert.NotNull(result);

//        var expectedUri = new Uri("https://jsonplaceholder.typicode.com/users");

//        handlerMock.Protected().Verify(
//           "SendAsync",
//           Times.Exactly(2), // we expected a single external request
//           ItExpr.Is<HttpRequestMessage>(req =>
//              req.Method == HttpMethod.Get
//              && req.RequestUri == expectedUri
//           ),
//           ItExpr.IsAny<CancellationToken>()
//        );
//    }
//}


public static MockedRequest RespondJson<T>(this MockedRequest request, T content)
    {
        request.Respond(req =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(content));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        });
        return request;
    }


   


    public static MockedRequest RespondJsonTherapist<Therapist>(this MockedRequest request, Therapist content)
    {
        request.Respond(req =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(content));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        });
        return request;
    }


    public static MockedRequest RespondJson<T>(this MockedRequest request, Func<T> contentProvider)
    {
        request.Respond(req =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(contentProvider()));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        });
        return request;
    }
}
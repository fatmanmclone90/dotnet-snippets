var useProxy = true;
var httpClientHandler = new HttpClientHandler();

if (useProxy)
{
    var proxy = new WebProxy
    {
        Address = new Uri($"http://127.0.0.1:8080"),
        BypassProxyOnLocal = false,
        UseDefaultCredentials = false,
    };
    httpClientHandler.Proxy = proxy;
}

var httpClient = new HttpClient(httpClientHandler)
{
    BaseAddress = new Uri("https://foo.com"),
};

public class TelemetryInitializer : ITelemetryInitializer
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public TelemetryInitializer(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public void Initialize(ITelemetry telemetry)
    {
        if (httpContextAccessor.HttpContext == null) return;

        var protocol = httpContextAccessor.HttpContext.Request.Protocol;

        if (telemetry is not ISupportProperties properties)
        {
            return;
        }

        properties.Properties["Protocol"] = protocol;

        foreach (var header in httpContextAccessor.HttpContext.Request.Headers)
        {
            properties.Properties[header.Key] = header.Value;
        }
    }
}

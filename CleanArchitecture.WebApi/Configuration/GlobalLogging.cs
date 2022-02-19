using Serilog;
using Serilog.AspNetCore;

namespace CleanArchitecture.WebApi.Configuration;

public static class GlobalLogging
{
    public static Action<RequestLoggingOptions> Configuration
    {
        get
        {
            return options =>
            {
                options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserName}) responded {StatusCode} in {Elapsed:0.0000}ms";
                options.EnrichDiagnosticContext = EnrichWithUserName;
            };
        }
    }

    public static Action<IDiagnosticContext, HttpContext> EnrichWithUserName
    {
        get
        {
            return (IDiagnosticContext diagnosticContext, HttpContext httpContext) =>
            {
                diagnosticContext.Set("UserName", httpContext.User.Identity?.Name ?? "Anonymous");
                diagnosticContext.Set("AuthenticationType", httpContext.User.Identity?.AuthenticationType ?? "Unknown");
            };
        }
    }
}

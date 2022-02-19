using CleanArchitecture.SharedKernel.Modules.Jwt;
using CleanArchitecture.SharedKernel.Services.UserManagement;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CleanArchitecture.WebApi.Configuration;

public static class GlobalErrorHandler
{
    public static Action<IApplicationBuilder> Configuration
    {
        get
        {
            return errorApp =>
            {
                errorApp.Run(async context =>
                {
                    //Enrich logs with the userId
                    var diagnosticContext = errorApp.ApplicationServices.GetRequiredService<IDiagnosticContext>();
                    if (!int.TryParse(ClaimsHelper.GetClaim(context.User, "uid"), out int uid)) uid = 0;
                    //if (uid != 0) 
                    diagnosticContext.Set("UserId", uid);

                    //Get the exception that was thrown
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;
                    var endpoint = exceptionHandlerPathFeature?.Endpoint;

                    //Determine status code
                    var statusCode = exception switch
                    {
                        UserNotAuthorizedException x => StatusCodes.Status401Unauthorized,
                        UserNotAuthenticatedException x => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status400BadRequest,
                    };

                    //Object to return
                    var pd = new ProblemDetails
                    {
                        Title = exception?.Message,
                        Status = statusCode,
                        Type = exception?.GetType().ToString(),
                    };
                    pd.Extensions.Add("endpoint", endpoint?.DisplayName);
                    pd.Extensions.Add("requestId", context.TraceIdentifier);

                    //Format and send response to client
                    context.Response.StatusCode = statusCode;
                    await context.Response.WriteAsJsonAsync(pd, pd.GetType(), null, contentType: "application/problem+json");
                });
            };
        }
    }
}

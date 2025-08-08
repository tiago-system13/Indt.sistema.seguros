﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;
using System.Text;

namespace Indt.Sistema.Seguros.Commons.Telemetria
{
    public class TelemetryMiddleware : IMiddleware
    {
        private static bool IRequestWitchBody(HttpRequest r) => r.Method == HttpMethod.Post.ToString() || r.Method == HttpMethod.Put.ToString();     
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var logger = Log.ForContext<TelemetryMiddleware>();
            var request = context.Request;

            if (IRequestWitchBody(request) && (!string.IsNullOrWhiteSpace(request.ContentType) && !request.ContentType.Contains("multipart/form-data")))
            {
                var requestBody = await GetRequestBodyForTelemetry(context);
                logger.Information("Request Body: {RequestBody}", requestBody);

            }

            var responseBody = await GetResponseBodyForTelemetry(context, next);

            if (!string.IsNullOrEmpty(responseBody))
                logger.Information("Response Body: {Response}", responseBody);
        }

        public static async Task<string> GetRequestBodyForTelemetry(HttpContext context)
        {
            var request = context.Request;

            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            request.Body.Position = 0;
            var sr = new StreamReader(request.Body, Encoding.UTF8);
            var bodyContent = await sr.ReadToEndAsync().ConfigureAwait(false);
            request.Body.Position = 0;

            return bodyContent;
        }

        public static async Task<string?> GetResponseBodyForTelemetry(HttpContext context, RequestDelegate next)
        {
            Stream originalBody = context.Response.Body;

            try
            {
                using (var stream = new MemoryStream())
                {
                    context.Response.Body = stream;
                    await next(context);
                    if (context.Response.StatusCode == (int)HttpStatusCode.NoContent) return null;

                    stream.Position = 0;
                    var responseBody = new StreamReader(stream).ReadToEnd();

                    stream.Position = 0;
                    await stream.CopyToAsync(originalBody);

                    return responseBody;

                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }

    public static class TelemetryMiddlewareExtensions
    {
        public static IApplicationBuilder UseTelemetryMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TelemetryMiddleware>();
        }
    }
}

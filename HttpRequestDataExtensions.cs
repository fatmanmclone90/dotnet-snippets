using Microsoft.Azure.Functions.Worker.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using Whds.ArticleMaster.DataIngest.FileSplitter.Extensions;

namespace Whds.ArticleMaster.DataIngest.FileSplitter.Extensions
{
    public static class HttpRequestDataExtensions
    {
        public static (T body, List<ValidationResult> validationResults) ExtractAndValidate<T>(
            this HttpRequestData request)
        {
            var body = JsonSerializer.Deserialize<T>(request.Body);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(
                body,
                new ValidationContext(
                    body,
                    null,
                    null),
                validationResults,
                true);

            return (body, validationResults);
        }

        public static async Task<HttpResponseData> CreateResponse<T>(
            this HttpRequestData httpRequest,
            HttpStatusCode statusCode,
            T body,
            CancellationToken cancellationToken)
        {
            var response = httpRequest.CreateResponse(statusCode);
            await response.WriteAsJsonAsync(
                body,
                cancellationToken);

            return response;
        }
    }
}

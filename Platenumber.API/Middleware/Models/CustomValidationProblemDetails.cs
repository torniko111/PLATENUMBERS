using Microsoft.AspNetCore.Mvc;

namespace Platenumbers.API.Middleware.Models
{
    public class CustomValidationProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}

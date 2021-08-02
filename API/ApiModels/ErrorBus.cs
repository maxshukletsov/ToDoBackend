using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;


namespace API.ApiModels
{
    public class ValidationErrorResult : ObjectResult
    {
        public ValidationErrorResult(ModelStateDictionary modelState) : base(new ErrorResponseModel(modelState)) =>
            StatusCode = StatusCodes.Status400BadRequest;
    }
    public class ErrorResponseModel
    {
        public List<string> Errors { get; }

        public ErrorResponseModel(ModelStateDictionary modelState)
        {
            Errors = modelState.Values
                .SelectMany(v => v.Errors
                    .Select(e => e.ErrorMessage))
                .ToList();
        }
    }
}
#nullable enable
using System.Collections.Generic;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Result
{
    public static class ApiResult
    {
        public static ActionResult<TResponseModel> Send<TResponseModel>(
            UseCaseStatus status,
            TResponseModel responseData,
            string message,
            ModelStateDictionary modelState,
            int okHttpStatus = 200
        ) =>
            status switch
            {
                UseCaseStatus.Ok => new ObjectResult(new ApiSuccessResponseModel<TResponseModel>(message, responseData))
                    {StatusCode = okHttpStatus},
                UseCaseStatus.BadRequest => new ObjectResult(new ApiBadRequestResponseModel(message)) {StatusCode = 400},
                UseCaseStatus.Unauthorized => new ObjectResult(new ApiUnauthorizedResponseModel(message)) {StatusCode = 401},
                UseCaseStatus.Forbidden => new ObjectResult(new ApiForbiddenResponseModel(message)) {StatusCode = 403},
                _ => new ObjectResult(new ApiNotFoundResponseModel(message)) {StatusCode = 404}
            };

        public static ActionResult Send(UseCaseStatus status,
            string message,
            ModelStateDictionary modelState,
            int okHttpStatus = 200) =>
            status switch
            {
                UseCaseStatus.Ok => new ObjectResult(new ApiDeletedResponseModel(message)) {StatusCode = okHttpStatus},
                UseCaseStatus.BadRequest => new ObjectResult(new ApiBadRequestResponseModel(message)) {StatusCode = 400},
                UseCaseStatus.Unauthorized => new ObjectResult(new ApiUnauthorizedResponseModel(message)) {StatusCode = 401},
                UseCaseStatus.Forbidden => new ObjectResult(new ApiForbiddenResponseModel(message)) {StatusCode = 403},
                _ => new ObjectResult(new ApiNotFoundResponseModel(message)) {StatusCode = 404}
            };

        public record ApiSuccessResponseModel<TResponseData>(string? Message, TResponseData Data);

        public record ApiDeletedResponseModel(string? Message);

        public record ApiBadRequestResponseModel(string? error);
        public record ApiUnauthorizedResponseModel(string? error);
        public record ApiForbiddenResponseModel(string? error);
        public record ApiNotFoundResponseModel(string? error);
        
    }
}
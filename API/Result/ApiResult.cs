#nullable enable
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
            };

        public static ActionResult Send(UseCaseStatus status,
            string message,
            ModelStateDictionary modelState,
            int okHttpStatus = 200) =>
            status switch
            {
                UseCaseStatus.Ok => new ObjectResult(new ApiDeletedResponseModel(message)) {StatusCode = okHttpStatus},
            };

        public record ApiSuccessResponseModel<TResponseData>(string? Message, TResponseData Data);

        public record ApiDeletedResponseModel(string? Message);
    }
}
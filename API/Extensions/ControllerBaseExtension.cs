using API.ApiModels;

using Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Extensions
{
    public static class ControllerBaseExtension
    {
        public static ActionResult<TResponseModel> ApiResult<TResponseModel>(this ControllerBase controller,
            ApiResultContext<TResponseModel> resultContext)
        {
            return resultContext.Status switch
            {
                UseCaseStatus.Ok => new ObjectResult(new ApiSuccessResponseModel<TResponseModel>()
                        {Message = resultContext.Message, Data = resultContext.Data})
                    {StatusCode = resultContext.OkHttpStatus},
                UseCaseStatus.BadRequest => BadRequestResult(resultContext.ModelState, resultContext.Message),
                UseCaseStatus.Forbidden => ForbiddenResult(resultContext.ModelState),
                UseCaseStatus.NotFound => NotFoundResult(resultContext.ModelState, resultContext.Message),
                UseCaseStatus.Unauthorized => UnauthorizedResult(resultContext.ModelState, resultContext.Message),
                _ => InternalServerErrorResult(resultContext.ModelState)
            };
        }

        public static ActionResult ApiResult(this ControllerBase controller,
            ApiResultContext resultContext)
        {
            return resultContext.Status switch
            {
                UseCaseStatus.Ok => new ObjectResult(new ApiSuccessResponseModel()
                    {Message = resultContext.Message}) {StatusCode = resultContext.OkHttpStatus},
                UseCaseStatus.BadRequest => BadRequestResult(resultContext.ModelState, resultContext.Message),
                UseCaseStatus.Forbidden => ForbiddenResult(resultContext.ModelState),
                UseCaseStatus.NotFound => NotFoundResult(resultContext.ModelState, resultContext.Message),
                UseCaseStatus.Unauthorized => UnauthorizedResult(resultContext.ModelState, resultContext.Message),
                _ => InternalServerErrorResult(resultContext.ModelState)
            };
        }

        private static ActionResult BadRequestResult(ModelStateDictionary modelState,
            string message)
        {
            modelState.AddModelError("", message);
            return new ValidationErrorResult(modelState) {StatusCode = 400};
        }

        private static ActionResult ForbiddenResult(ModelStateDictionary modelState)
        {
            modelState.AddPermissionError();
            return new ValidationErrorResult(modelState) {StatusCode = 403};
        }

        private static ActionResult NotFoundResult(ModelStateDictionary modelState,
            string message)
        {
            modelState.AddModelError("", message);
            return new ValidationErrorResult(modelState) {StatusCode = 404};
        }

        private static ActionResult UnauthorizedResult(ModelStateDictionary modelState, string message)
        {
            modelState.AddModelError("", message);
            return new ValidationErrorResult(modelState) {StatusCode = 401};
        }

        private static ActionResult InternalServerErrorResult(ModelStateDictionary modelState)
        {
            modelState.AddModelError("", "Внутренняя ошибка сервера, повторите запрос позже");
            return new ValidationErrorResult(modelState) {StatusCode = 500};
        }
        
        public class ValidationErrorResult : ObjectResult
        {
            public ValidationErrorResult(ModelStateDictionary modelState) : base(new ErrorResponseModel(modelState)) =>
                StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
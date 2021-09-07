#nullable enable

namespace Domain.SeedWork
{
    public record UseCaseResult<TDataType>
    {
        public UseCaseStatus Status;
        public string? Message;
        public TDataType Data;

        public void Deconstruct(out UseCaseStatus status, out TDataType? data, out string? message) =>
            (status, data, message) = (Status, Data, Message);
    }

    public record UseCaseResult
    {
        public UseCaseStatus Status;
        public string? Message;

        public void Deconstruct(out UseCaseStatus status, out string? message) =>
            (status, message) = (Status, Message);
    }

    public static class Result
    {
        // OK request
        public static UseCaseResult<TDataType> Ok<TDataType>(TDataType data, string message = "") =>
            new() { Status = UseCaseStatus.Ok, Data = data, Message = message };

        public static UseCaseResult Ok(string message = "") =>
            new() { Status = UseCaseStatus.Ok, Message = message };

        // Bad Request

        public static UseCaseResult<TDataType> BadRequest<TDataType>(TDataType data, string message = "") =>
            new() { Status = UseCaseStatus.BadRequest, Data = data, Message = message };

        public static UseCaseResult BadRequests(string message = "") =>
            new() { Status = UseCaseStatus.BadRequest, Message = message };

        // Not Found
        public static UseCaseResult<TDataType> NotFound<TDataType>(TDataType data, string message = "") =>
            new() { Status = UseCaseStatus.NotFound, Data = data, Message = message };

        public static UseCaseResult NotFound(string message = "") =>
            new() { Status = UseCaseStatus.NotFound, Message = message };

        //Forbiden

        public static UseCaseResult<TDataType> Forbidden<TDataType>(TDataType data, string message = "") =>
            new() { Status = UseCaseStatus.Forbidden, Data = data, Message = message };

        public static UseCaseResult Forbidden(string message = "") =>
            new() { Status = UseCaseStatus.Forbidden, Message = message };
    }
}
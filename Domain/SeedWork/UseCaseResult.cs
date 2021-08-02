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
        public static UseCaseResult<TDataType> Ok<TDataType>(TDataType data, string message = "") =>
            new() {Status = UseCaseStatus.Ok, Data = data, Message = message};

        public static UseCaseResult Ok(string message = "") =>
            new() {Status = UseCaseStatus.Ok, Message = message};
    }
}
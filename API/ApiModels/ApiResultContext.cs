#nullable enable

using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.ApiModels
{
    public record ApiResultContext<TDataType>
    {
        public UseCaseStatus Status;
        public string Message = "";
        public TDataType Data;
        public ModelStateDictionary ModelState;
        public int OkHttpStatus = 200;
    }

    public record ApiResultContext
    {
        public UseCaseStatus Status;
        public string Message = "";
        public ModelStateDictionary ModelState;
        public int OkHttpStatus = 200;
    }
}
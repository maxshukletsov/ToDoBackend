#nullable enable
namespace API.ApiModels
{
    public class ApiSuccessResponseModel<TResponseData>
    {
        public string? Message;
        public TResponseData Data;
    }

    public class ApiSuccessResponseModel
    {
        public string? Message;
    }
}
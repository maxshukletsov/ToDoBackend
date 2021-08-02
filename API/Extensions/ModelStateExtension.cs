using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddPermissionError(this ModelStateDictionary modelState)
        {
            modelState.AddModelError("", "У вас нет прав для этой операции");
        }

        public static void AddNotFoundError(this ModelStateDictionary modelState, string message)
        {
            modelState.AddModelError("", message);
        }
    }
}
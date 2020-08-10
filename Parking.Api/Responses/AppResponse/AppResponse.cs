using Microsoft.AspNetCore.Mvc;

namespace Parking.Api.Responses.AppResponse
{
    public class AppResponse : ActionResult
    {
        public static SuccessResponse Success(object data) => new SuccessResponse(data);
        // public static ErrorResponse<T> Error(T errors) => new ErrorResponse<T>(errors);
    }
}
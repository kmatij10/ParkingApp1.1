namespace Parking.Api.Responses.AppResponse
{
    public class SuccessResponse
    {
        public SuccessResponse(object response) => Response = response;

        public object Response { get; }
        public bool Success { get; set; } = true;
    }
}
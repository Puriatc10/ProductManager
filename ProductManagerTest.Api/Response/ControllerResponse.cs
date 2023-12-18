using ProductManagerTest.Api.Response.Enum;

namespace ProductManagerTest.Api.Response
{
    public class ControllerResponse
    {
        public ControllerResponse(Status status, object data, string message = "")
        {
            Status = status.ToString();
            Message = message;
            Data = data;
        }
        public string Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}

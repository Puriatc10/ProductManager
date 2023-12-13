using ProductManagerTest.Api.Response.Enum;

namespace ProductManagerTest.Api.Response
{
    public static class CreateResponse
    {
        public static ControllerResponse Error(object data, string message = "")
        {
            var response = new ControllerResponse(Status.Failed, data, message);
            return response;
        }

        public static ControllerResponse Ok(object data)
        {
            var response = new ControllerResponse(Status.Success, data, "عملیات با موفقیت انجام شد");
            return response;
        }

        public static ControllerResponse Ok(object data, string message)
        {
            var response = new ControllerResponse(Status.Success, data, message);
            return response;
        }

        public static ControllerResponse Ok()
        {
            var response = new ControllerResponse(Status.Success, null, "عملیات با موفقیت انجام شد");
            return response;
        }
    }
}

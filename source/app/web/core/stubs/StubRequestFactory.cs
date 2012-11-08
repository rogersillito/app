using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IContainRequestDetails create_controller_request_from(HttpContext a_new_asp_net_context)
    {
      return new StubRequest();
    }

    class StubRequest : IContainRequestDetails
    {
    }
  }
}
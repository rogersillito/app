using System.Web;

namespace app.web.core
{
  public interface ICreateControllerRequests
  {
    IContainRequestDetails create_controller_request_from(HttpContext a_new_asp_net_context);
  }
}
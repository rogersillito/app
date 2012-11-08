using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    ICreateViewsForReports view_factory;
    IGetTheCurrentlyExecutingWebRequest current_request;

    public WebFormDisplayEngine():this(new WebFormFactory(),() => HttpContext.Current)
    {
    }

    public WebFormDisplayEngine(ICreateViewsForReports view_factory, IGetTheCurrentlyExecutingWebRequest current_request)
    {
      this.view_factory = view_factory;
      this.current_request = current_request;
    }

    public void display<ReportModel>(ReportModel model)
    {
      var view = view_factory.create_view_that_can_display(model);
      view.ProcessRequest(current_request());
    }
  }
}
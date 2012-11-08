using System.Web;

namespace app.web.core.aspnet
{
    public class WebFormDisplayEngine : IDisplayInformation
    {
        ICreateViewsForReports view_factory;
        readonly HttpContext http_context;

        public WebFormDisplayEngine(ICreateViewsForReports view_factory, HttpContext http_context)
        {
            this.view_factory = view_factory;
            this.http_context = http_context;
        }

        public void display<ReportModel>(ReportModel model)
        {
            IHttpHandler view = view_factory.create_view_that_can_display(model);
            view.ProcessRequest(http_context);
        }
    }
}
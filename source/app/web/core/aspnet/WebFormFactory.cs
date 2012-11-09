using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormFactory : ICreateViewsForReports
  {
    ICreatePageInstances page_factory;
    IFindPathsToPages path_registry;

    public WebFormFactory(ICreatePageInstances page_factory, IFindPathsToPages path_registry)
    {
      this.page_factory = page_factory;
      this.path_registry = path_registry;
    }

    public IHttpHandler create_view_that_can_display<TReportModel>(TReportModel report_model)
    {
      var page =
        (IDisplayA<TReportModel>) page_factory(path_registry.get_the_path_to_the_page_that_displays<TReportModel>(),
                                               typeof(IDisplayA<TReportModel>));
      page.report = report_model;
      return page;
    }
  }
}
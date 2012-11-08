namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine: IDisplayInformation
  {
      ICreateViewsForReports view_factory;
      public WebFormDisplayEngine(ICreateViewsForReports view_factory)
      {
          this.view_factory = view_factory;
      }

      public void display<ReportModel>(ReportModel model)
    {
      view_factory.create_view_that_can_display(model);
    }
  }
}
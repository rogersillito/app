using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewAReport<ReportModel> : ISupportAUserFeature
  {
    IFetchInformation<ReportModel> query;
    IDisplayInformation display_engine;

    public ViewAReport(IFetchInformation<ReportModel> query, IDisplayInformation display_engine)
    {
      this.query = query;
      this.display_engine = display_engine;
    }

    public void run(IContainRequestDetails request)
    {
      display_engine.display(query(request));
    }
  }
}
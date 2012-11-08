using app.web.core;
using app.web.core.stubs;

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

    public ViewAReport(IFetchInformation<ReportModel> query) : this(query, new StubDisplayEngine())
    {
    }

    public ViewAReport(IFetchAReport<ReportModel> query_object):this(query_object.fetch_using)
    {
    }

    public void run(IContainRequestDetails request)
    {
      display_engine.display(query(request));
    }
  }
}
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewInformation<ReportModel> : ISupportAUserFeature
  {
    IFetchInformation<ReportModel> query;
    IDisplayInformation display_engine;

    public ViewInformation(IFetchInformation<ReportModel> query, IDisplayInformation display_engine)
    {
      this.query = query;
      this.display_engine = display_engine;
    }

    public ViewInformation(IFetchInformation<ReportModel> query) : this(query, new StubDisplayEngine())
    {
    }

    public ViewInformation(IFetchAReport<ReportModel> query_object):this(query_object.fetch_using)
    {
    }

    public void run(IContainRequestDetails request)
    {
      display_engine.display(query(request));
    }
  }
}
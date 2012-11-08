namespace app.web.core
{
  public interface IFetchAReport<ReportModel>
  {
    ReportModel fetch_using(IContainRequestDetails request);
  }
  public delegate ReportModel IFetchInformation<ReportModel>(IContainRequestDetails request);
}
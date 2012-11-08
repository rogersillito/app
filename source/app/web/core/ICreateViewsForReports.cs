namespace app.web.core
{
  public interface ICreateViewsForReports
  {
    void create_view_that_can_display<TReportModel>(TReportModel report_model);
  }
}
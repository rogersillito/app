namespace app.web.core.aspnet
{
  public interface IFindPathsToPages
  {
    string get_the_path_to_the_page_that_displays<TReportModel>();
  }
}
using System.Security;

namespace app.web.core
{
  public class SecuredQuery<TReportModel> : IFetchAReport<TReportModel>
  {
    IFetchAReport<TReportModel> original_query;
    IDetermineIfAQueryCanBeRun request_constraint;

    public SecuredQuery(IFetchAReport<TReportModel> original_query, IDetermineIfAQueryCanBeRun request_constraint)
    {
      this.original_query = original_query;
      this.request_constraint = request_constraint;
    }

    public TReportModel fetch_using(IContainRequestDetails request)
    {
      if (request_constraint(request)) return original_query.fetch_using(request);

      throw new SecurityException();
    }
  }
}
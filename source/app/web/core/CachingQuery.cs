using System;
using System.Collections.Generic;

namespace app.web.core
{
  public class CachingQuery<TReportModel> : IFetchAReport<TReportModel>
  {
    IFetchAReport<TReportModel> query;
    IDetermineIfACacheItemNeedsToBeRefreshed cache_refresh_policy;
    IDictionary<Type, object> cache;

    public CachingQuery(IFetchAReport<TReportModel> query, IDetermineIfACacheItemNeedsToBeRefreshed cache_refresh_policy, IDictionary<Type, object> cache)
    {
      this.query = query;
      this.cache_refresh_policy = cache_refresh_policy;
      this.cache = cache;
    }

    public TReportModel fetch_using(IContainRequestDetails request)
    {
      if (cache_refresh_policy.needs_refresh<TReportModel>())
      {
        cache[typeof(TReportModel)] = query.fetch_using(request);
      }
      return (TReportModel)cache[typeof(TReportModel)];
    }
  }
}
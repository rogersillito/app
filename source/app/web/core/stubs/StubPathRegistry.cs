using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubPathRegistry : IFindPathsToPages
  {
    public string get_the_path_to_the_page_that_displays<TReportModel>()
    {
      var paths = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<DepartmentItem>), create_path_to("DepartmentBrowser")},
        {typeof(IEnumerable<ProductItem>), create_path_to("ProductBrowser")}
      };

      return paths[typeof(TReportModel)];
    }

    string create_path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }
  }
}
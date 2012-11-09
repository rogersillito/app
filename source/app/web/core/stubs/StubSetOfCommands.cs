using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield break;
    }

    IProcessOneRequest build_report_for<TQueryObject, TModel>() where TQueryObject : IFetchAReport<TModel>, new()
    {
      throw new NotImplementedException();
    }

    public class GetTheDepartmentsInADepartment : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IContainRequestDetails request)
      {
        return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Child Department 0")});
      }
    }

    public class GetTheMainDepartments : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IContainRequestDetails request)
      {
        return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
      }
    }

    public class GetTheProductsInADepartment : IFetchAReport<IEnumerable<ProductItem>>
    {
      public IEnumerable<ProductItem> fetch_using(IContainRequestDetails request)
      {
        return Enumerable.Range(1, 100).Select(x => new ProductItem {name = x.ToString("Product 0")});
      }
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

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
      yield return build_report_for<GetTheProductsInADepartment, IEnumerable<ProductItem>>();
      yield return build_report_for<GetTheMainDepartments, IEnumerable<DepartmentItem>>();
      yield return build_report_for<GetTheDepartmentsInADepartment, IEnumerable<DepartmentItem>>();
    }

    IProcessOneRequest build_report_for<TQueryObject, TModel>() where TQueryObject : IFetchAReport<TModel>,new()
    {
      return new RequestCommand(x => true, new ViewInformation<TModel>(new TQueryObject()));  
    }

    public class GetTheDepartmentsInADepartment : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IContainRequestDetails request)
      {
        return new StubStoreCatalog().get_the_departments_using(request.map<ViewTheDepartmentsInADepartmentRequest>());
      }
    }

    public class GetTheMainDepartments : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IContainRequestDetails request)
      {
        return new StubStoreCatalog().get_the_main_departments();
      }
    }

    public class GetTheProductsInADepartment : IFetchAReport<IEnumerable<ProductItem>>
    {
      public IEnumerable<ProductItem> fetch_using(IContainRequestDetails request)
      {
        return new StubStoreCatalog().get_the_products_using(request.map<ViewTheProductsInADepartmentRequest>());
      }
    }
  }
}
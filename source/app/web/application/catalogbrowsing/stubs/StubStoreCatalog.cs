using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubStoreCatalog : IFindInformationInTheStore
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_the_departments_using(
      ViewTheDepartmentsInADepartmentRequest view_departments_in_department_request)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Child Department 0")});
    }

    public IEnumerable<ProductItem> get_the_products_using(
      ViewTheProductsInADepartmentRequest view_products_in_department_request)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem {name = x.ToString("Product 0")});
    }
  }
}
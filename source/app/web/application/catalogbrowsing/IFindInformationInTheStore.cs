using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindInformationInTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();

    IEnumerable<DepartmentItem> get_the_departments_using(
      ViewTheDepartmentsInADepartmentRequest view_departments_in_department_request);

    IEnumerable<ProductItem> get_the_products_using(
      ViewTheProductsInADepartmentRequest view_products_in_department_request);
  }
}
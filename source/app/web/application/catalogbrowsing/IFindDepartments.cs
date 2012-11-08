﻿using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
    IEnumerable<DepartmentItem> get_the_departments_using(ViewTheDepartmentsInADepartmentRequest view_departments_in_department_request);
  }
}
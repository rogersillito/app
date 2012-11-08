using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsInADepartment))]
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        department_repository = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        the_departments_in_a_department = new List<DepartmentItem>();
        view_departments_in_department_request = new ViewTheDepartmentsInADepartmentRequest();

        request.setup(x => x.map<ViewTheDepartmentsInADepartmentRequest>()).Return(view_departments_in_department_request);

        department_repository.setup(x => x.get_the_departments_using(view_departments_in_department_request)).Return(the_departments_in_a_department);
      };

      Because b = () =>
        sut.run(request);

      It should_display_the_list_of_the_departments_in_the_department = () =>
        display_engine.received(x => x.display(the_departments_in_a_department));


      static IFindDepartments department_repository;
      static IContainRequestDetails request;
      static IEnumerable<DepartmentItem> the_departments_in_a_department;
      static IDisplayInformation display_engine;
      static ViewTheDepartmentsInADepartmentRequest view_departments_in_department_request;
    }
  }
}
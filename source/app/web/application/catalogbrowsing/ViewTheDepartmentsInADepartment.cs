using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheDepartmentsInADepartment : ISupportAUserFeature
  {
    IFindDepartments department_repository;
    IDisplayInformation display_engine;

    public ViewTheDepartmentsInADepartment(IFindDepartments department_repository, IDisplayInformation display_engine)
    {
      this.department_repository = department_repository;
      this.display_engine = display_engine;
    }

    public ViewTheDepartmentsInADepartment() : this(new StubDepartmentRepository(), new StubDisplayEngine())
    {
    }

    public void run(IContainRequestDetails request)
    {
      display_engine.display(
        department_repository.get_the_departments_using(request.map<ViewTheDepartmentsInADepartmentRequest>()));
    }
  }
}
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheDepartmentsInADepartment : ISupportAUserFeature
  {
    IFindInformationInTheStore information_in_the_store_repository;
    IDisplayInformation display_engine;

    public ViewTheDepartmentsInADepartment(IFindInformationInTheStore information_in_the_store_repository, IDisplayInformation display_engine)
    {
      this.information_in_the_store_repository = information_in_the_store_repository;
      this.display_engine = display_engine;
    }

    public ViewTheDepartmentsInADepartment() : this(new StubStoreCatalog(), new StubDisplayEngine())
    {
    }

    public void run(IContainRequestDetails request)
    {
      display_engine.display(
        information_in_the_store_repository.get_the_departments_using(request.map<ViewTheDepartmentsInADepartmentRequest>()));
    }
  }
}
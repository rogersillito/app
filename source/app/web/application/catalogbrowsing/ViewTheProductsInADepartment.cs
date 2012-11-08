using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheProductsInADepartment : ISupportAUserFeature
  {
    IFindInformationInTheStore product_repository;
    IDisplayInformation view_engine;

    public ViewTheProductsInADepartment(IDisplayInformation view_engine, IFindInformationInTheStore product_repository)
    {
      this.view_engine = view_engine;
      this.product_repository = product_repository;
    }

    public ViewTheProductsInADepartment():this(new StubDisplayEngine(),new StubStoreCatalog())
    {
    }

    public void run(IContainRequestDetails request)
    {
      view_engine.display(product_repository.get_the_products_using(request.map<ViewTheProductsInADepartmentRequest>()));
    }
  }
}
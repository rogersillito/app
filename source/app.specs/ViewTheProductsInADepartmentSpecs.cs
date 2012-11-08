using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheProductsInADepartment))]
  public class ViewTheProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish context = () =>
      {
        request = fake.an<IContainRequestDetails>();
        product_repository = depends.on<IFindInformationInTheStore>();
        display_engine = depends.on<IDisplayInformation>();
        the_products_in_a_department = new List<ProductItem>();
        view_products_in_department_request = new ViewTheProductsInADepartmentRequest();
        request.setup(x => x.map<ViewTheProductsInADepartmentRequest>()).Return(view_products_in_department_request);
        product_repository.setup(x => x.get_the_products_using(view_products_in_department_request)).Return(
          the_products_in_a_department);
      };

      Because of = () =>
      {
        sut.run(request);
      };

      It should_display_the_list_of_products_in_the_department = () =>
      {
        display_engine.received(x => x.display(the_products_in_a_department));
      };

      static IDisplayInformation display_engine;
      static IContainRequestDetails request;
      static IFindInformationInTheStore product_repository;
      static IEnumerable<ProductItem> the_products_in_a_department;
      static ViewTheProductsInADepartmentRequest view_products_in_department_request;
    }
  }
}
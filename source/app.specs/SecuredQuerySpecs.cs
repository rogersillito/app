using System.Security;
using System.Security.Principal;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(SecuredQuery<>))]
  public class SecuredQuerySpecs
  {
    public abstract class concern : Observes<IFetchAReport<ViewAReportSpecs.AnItem>,
                                      SecuredQuery<ViewAReportSpecs.AnItem>>
    {
    }

    public class when_fetching_the_information : concern
    {
      public class and_the_security_constraint_is_met
      {
        Establish c = () =>
        {
          request = fake.an<IContainRequestDetails>();
          original_query = depends.on<IFetchAReport<ViewAReportSpecs.AnItem>>();
          depends.on<IDetermineIfAQueryCanBeRun>(x => x == request);
          the_item = new ViewAReportSpecs.AnItem();

          original_query.setup(x => x.fetch_using(request)).Return(the_item);
        };

        Because b = () =>
          result = sut.fetch_using(request);

        It should_return_the_information_from_the_original_query = () =>
          result.ShouldEqual(the_item);

        static ViewAReportSpecs.AnItem result;
        static ViewAReportSpecs.AnItem the_item;
        static IContainRequestDetails request;
        static IFetchAReport<ViewAReportSpecs.AnItem> original_query;
        static IPrincipal the_current_principal;
      }

      public class and_the_constraint_is_not_met
      {
        Establish c = () =>
        {
          request = fake.an<IContainRequestDetails>();
          original_query = depends.on<IFetchAReport<ViewAReportSpecs.AnItem>>();
          depends.on<IDetermineIfAQueryCanBeRun>(x => false);
        };

        Because b = () =>
          spec.catch_exception(() => sut.fetch_using(request));

        It should_not_attempt_to_run_the_original_query = () =>
          original_query.never_received(x => x.fetch_using(request));
          
        It should_throw_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IContainRequestDetails request;
        static IFetchAReport<ViewAReportSpecs.AnItem> original_query;
      }
    }
  }
}
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(RequestCommand))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        depends.on<IMatchARequest>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_run(request);

      It should_make_the_decision_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static IContainRequestDetails request;
      static bool result;
    }

    public class when_running_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        feature = depends.on<ISupportAUserFeature>();
      };

      Because b = () =>
        sut.run(request);

      It should_run_the_application_feature_using_the_request = () =>
        feature.received(x => x.run(request));

      static IContainRequestDetails request;
      static ISupportAUserFeature feature;
    }
  }
}
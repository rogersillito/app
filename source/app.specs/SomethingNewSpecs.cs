using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(SomethingNew))]
  public class SomethingNewSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      SomethingNew>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        display_engine = depends.on<IDisplayInformation>();
      };

      Because b = () =>
        sut.run(request);

      It should_display_the_list_of_the_departments_in_the_department = () =>
        display_engine.received(x => x.display(some_item));


      static IContainRequestDetails request;
      static IDisplayInformation display_engine;
      static object some_item;
    }
  }
}
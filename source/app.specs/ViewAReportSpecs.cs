using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewAReport<>))]
  public class ViewAReportSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewAReport<AnItem>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        display_engine = depends.on<IDisplayInformation>();
        some_item = new AnItem();
        depends.on<IFetchInformation<AnItem>>(x =>
        {
          x.ShouldEqual(request);
          return some_item;
        });
      };

      Because b = () =>
        sut.run(request);

      It should_display_the_item_retrieved_by_its_query = () =>
        display_engine.received(x => x.display(some_item));

      static IContainRequestDetails request;
      static IDisplayInformation display_engine;
      static AnItem some_item;
    }

    public class AnItem
    {
    }
  }
}
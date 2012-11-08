using Machine.Specifications;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_information : concern
    {
      Establish c = () =>
      {
        view_model = new ViewAReportSpecs.AnItem();
        view_factory = depends.on<ICreateViewsForReports>();
      };

      Because b = () =>
        sut.display(view_model);


      It should_create_the_view_that_can_display_the_model = () =>
        view_factory.received(x => x.create_view_that_can_display(view_model));


      static ViewAReportSpecs.AnItem view_model;
      static ICreateViewsForReports view_factory;
    }
  }
}
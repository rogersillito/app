using System.Web;
using Machine.Specifications;
using app.specs.utility;
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
        view = fake.an<IHttpHandler>();

        the_current_context = depends.on(ObjectFactory.web.create_http_context());
        view_factory = depends.on<ICreateViewsForReports>();

        view_factory.setup(x => x.create_view_that_can_display(view_model)).Return(view);
      };

      Because b = () =>
        sut.display(view_model);


      It should_tell_the_view_to_render = () =>
        view.received(x => x.ProcessRequest(the_current_context));
        

      static ViewAReportSpecs.AnItem view_model;
      static ICreateViewsForReports view_factory;
      static IHttpHandler view;
      static HttpContext the_current_context;
    }
  }
}
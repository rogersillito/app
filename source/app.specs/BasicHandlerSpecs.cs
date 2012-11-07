 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(BasicHandler))]  
  public class BasicHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      BasicHandler>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateControllerRequests>();
        a_new_asp_net_context = ObjectFactory.web.create_http_context();
        new_controller_request = fake.an<IContainRequestDetails>();

        request_factory.setup(x => x.create_controller_request_from(a_new_asp_net_context)).Return(
          new_controller_request);
      };

      Because b = () =>
        sut.ProcessRequest(a_new_asp_net_context);

      It should_delegate_the_processing_of_a_new_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(new_controller_request));

      static IProcessRequests front_controller;
      static IContainRequestDetails new_controller_request;
      static HttpContext a_new_asp_net_context;
      static ICreateControllerRequests request_factory;
    }
  }
}

 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests,
                                      FrontController>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        command_registry = depends.on<IFindCommands>();
        command_that_can_run_the_request = fake.an<IProcessOneRequest>();
        request = fake.an<IContainRequestDetails>();

        command_registry.setup(x => x.get_the_command_that_can_run(request)).Return(command_that_can_run_the_request);
      };

      Because b = () =>
        sut.process(request);


      It should_delegate_the_processing_of_the_request_to_the_command_that_can_run_the_request = () =>
        command_that_can_run_the_request.received(x => x.run(request));

      static IProcessOneRequest command_that_can_run_the_request;
      static IContainRequestDetails request;
      static IFindCommands command_registry;
    }
  }
}

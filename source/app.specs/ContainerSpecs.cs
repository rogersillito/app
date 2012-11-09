 using Machine.Specifications;
 using app.utility.containers;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(Container))]  
  public class ContainerSpecs
  {
    public abstract class concern : Observes
    {
        
    }

   
    public class when_providing_access_to_service_locator_style_dependency_resolution : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IFetchDependencies>();
        IProvideAccessToTheContainerFacade resolution = () => the_container_facade;
        spec.change(() => Container.facade_resolution).to(resolution);
      };

      Because b = () =>
       result =  Container.fetch;

      It should_return_the_container_facade_it_was_provided_at_startup = () =>
        result.ShouldEqual(the_container_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_container_facade;
    }
  }
}

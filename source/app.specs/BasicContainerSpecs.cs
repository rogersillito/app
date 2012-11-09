using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(BasicContainer))]
  public class BasicContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      BasicContainer>
    {
    }

    public class when_fetching_a_dependency : concern
    {
      It first_observation = () => 
    }
  }
}
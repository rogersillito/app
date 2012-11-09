using System.Collections.Generic;
using System.Runtime.Serialization;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.extensions;
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
            Establish c = () =>
            {
                implementation_finder = depends.on<IFindImplementations<ISerializable>>();
                fake_implementations = fake.an<IEnumerable<ISerializable>>();
                implementation_finder.setup(x => x.list_all_implementations()).Return(fake_implementations);
            };

            Because b = () =>
                sut.an<ISerializable>();

            It should_delegate_finding_a_list_of_implementations_of_the_dependent_contract = () =>
                implementation_finder.received(x => x.list_all_implementations());

            static IFindImplementations<ISerializable> implementation_finder;
            static IEnumerable<ISerializable> fake_implementations;
        }
    }
}
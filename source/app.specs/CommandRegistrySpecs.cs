using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(CommandRegistry))]
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
    }

    public class when_finding_a_command_to_run_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
      };
      Because b = () =>
        result = sut.get_the_command_that_can_run(request);

      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          the_command_that_can_run = fake.an<IProcessOneRequest>();
          all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          all_the_commands.Add(the_command_that_can_run);
          
          the_command_that_can_run.setup(x => x.can_run(request)).Return(true);

          depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);
        };

        It should_return_the_command_that_can_process_the_request = () =>
          result.ShouldEqual(the_command_that_can_run);

        static IProcessOneRequest the_command_that_can_run;
        static List<IProcessOneRequest> all_the_commands;
      }
      static IProcessOneRequest result;
      static IContainRequestDetails request;
    }
  }
}
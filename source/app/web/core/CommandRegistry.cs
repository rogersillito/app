using System;
using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
    ICreateTheCommandForARequestWhenItIsNotFound special_case_factory;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands,
                           ICreateTheCommandForARequestWhenItIsNotFound special_case_factory)
    {
      this.commands = commands;
      this.special_case_factory = special_case_factory;
    }

    public CommandRegistry():this(new StubSetOfCommands(),
                                  () =>
                                  {
                                    throw new NotImplementedException("You don't have the command");
                                  })
    {
    }

    public IProcessOneRequest get_the_command_that_can_run(IContainRequestDetails request)
    {
      return commands.FirstOrDefault(x => x.can_run(request)) ?? special_case_factory();
    }
  }
}
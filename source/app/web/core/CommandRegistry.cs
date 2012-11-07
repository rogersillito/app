using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
    {
      this.commands = commands;
    }

    public IProcessOneRequest get_the_command_that_can_run(IContainRequestDetails request)
    {
      return commands.First(x => x.can_run(request));
    }
  }

}
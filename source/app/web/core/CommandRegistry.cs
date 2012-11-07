using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
      readonly MissingCommandFactory_Behaviour function_tohandle_command_not_found;

      public CommandRegistry(IEnumerable<IProcessOneRequest> commands, MissingCommandFactory_Behaviour function_tohandle_command_not_found)
    {
        this.commands = commands;
        this.function_tohandle_command_not_found = function_tohandle_command_not_found;
    }

      public IProcessOneRequest get_the_command_that_can_run(IContainRequestDetails request)
      {
          var command = commands.First(x => x.can_run(request));
          if (command == null)
              return function_tohandle_command_not_found();
          return command;
      }
  }

}
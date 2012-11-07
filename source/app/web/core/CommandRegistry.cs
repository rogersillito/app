using System.Collections.Generic;

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
          foreach (var command in commands)
          {
              if (command.can_run(request))
                  return command;
          }
          return new EmptyCommand();
    }
  }

    public class EmptyCommand :IProcessOneRequest
    {
        public void run(IContainRequestDetails request)
        {
            
        }

        public bool can_run(IContainRequestDetails request)
        {
            throw new System.NotImplementedException();
        }
    }
}
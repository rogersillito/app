using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new RequestCommand(x => true, new SomethingNew());
      yield return new RequestCommand(x => true, new SomethingNew());
      yield return new RequestCommand(x => true, new SomethingNew());
//      yield return new RequestCommand(x => true, new ViewTheProductsInADepartment());
//      yield return new RequestCommand(x => true, new ViewTheDepartmentsInADepartment());
//      yield return new RequestCommand(x => true, new ViewTheMainDepartmentsInTheStore());
    }
  }
}
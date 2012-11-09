using System;

namespace app.utility.containers
{
  public class Container
  {
      public static IProvideAccessToTheContainerFacade facade_resolution = () =>
    {
      throw new NotImplementedException("This should be configured by a startup pipeline");
    };

    public static IFetchDependencies fetch
    {
        get { return facade_resolution(); }
    }
  }
}
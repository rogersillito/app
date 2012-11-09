using System.Collections.Generic;

namespace app.utility.containers
{
    public interface IFindImplementations<TDependency>
    {
        IEnumerable<TDependency> list_all_implementations();
    }
}
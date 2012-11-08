using System;

namespace app.web.core.aspnet
{
  public delegate object ICreatePageInstances(string path,Type page_type);
}
using System.Web;
using System.Web.UI;

namespace app.web.core.aspnet
{
  public interface IDisplayA<TReport> : IHttpHandler
  {
    TReport report { get; set; }
  }

  public class SimpleReport<TReport> : Page, IDisplayA<TReport>
  {
    public TReport report { get; set; }
  }
}
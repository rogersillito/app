namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void run(IContainRequestDetails request);
    bool can_run(IContainRequestDetails request);
  }
}
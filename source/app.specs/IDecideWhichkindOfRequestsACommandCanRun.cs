namespace app.web.core
{
    public interface IDecideWhichKindOfRequestsACommandCanRun
    {
        bool CanHandleRequest(IContainRequestDetails request);
    }
}
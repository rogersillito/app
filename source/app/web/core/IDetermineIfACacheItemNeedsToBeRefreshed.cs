namespace app.web.core
{
  public interface IDetermineIfACacheItemNeedsToBeRefreshed
  {
    bool needs_refresh<TCacheItem>();
  }
}
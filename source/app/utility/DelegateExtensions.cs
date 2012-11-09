using System;

namespace app.utility
{
  public static class DelegateExtensions
  {
    public static Func<TItem> memoize<TItem>(this Func<TItem> original_method)
    {
      var result = default(TItem);
      var is_in_cache = false;

      return () =>
      {
        if (is_in_cache) return result;
        result = original_method();
        is_in_cache = true;
        return result;
      };
    }
  }
}
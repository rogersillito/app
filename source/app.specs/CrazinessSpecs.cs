using System;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Machine.Specifications;
using app.utility;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class CrazinessSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_playing_with_expressions
    {
      It should_be_able_to_build_a_tree_dynamically = () =>
      {
        Func<int,bool> is_even = x => x%2 == 0;

        
      };
    }

    public class when_applying_the_concept_of_caching_at_a_functional_level : concern
    {
      Establish c = () =>
      {
        target = () => new SqlConnection();
      };

      Because b = () =>
        target = target.memoize();

      It should_be_able_to_add_caching_to_any_method = () =>
      {
        var result = target();
        result.ShouldEqual(target());
      };
      static Func<object> target;
    }
  }
}
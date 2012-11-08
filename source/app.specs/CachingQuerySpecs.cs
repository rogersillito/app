 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(CachingQuery<>))]  
  public class CachingQuerySpecs
  {
    public abstract class concern : Observes<IFetchAReport<ViewAReportSpecs.AnItem>,
                                      CachingQuery<ViewAReportSpecs.AnItem>>
    {
        
    }

   
    public class when_run : concern
    {
      Because b = () =>
       result = sut.fetch_using(request);


      public class and_the_item_is_not_in_the_cache
      {
        Establish c = () =>
        {
          the_item = new ViewAReportSpecs.AnItem();
          original = depends.on<IFetchAReport<ViewAReportSpecs.AnItem>>();
          cache_refresh_policy = depends.on<IDetermineIfACacheItemNeedsToBeRefreshed>();
          cache = depends.on<IDictionary<Type, object>>(new Dictionary<Type, object>());

          cache_refresh_policy.setup(x => x.needs_refresh<ViewAReportSpecs.AnItem>()).Return(true);
          original.setup(x => x.fetch_using(request)).Return(the_item);
        };

        It should_store_the_result_of_the_original_query_in_the_cache = () =>
          cache[typeof(ViewAReportSpecs.AnItem)].ShouldEqual(the_item);

        It should_return_the_item = () =>
          result.ShouldEqual(the_item);
          

        static IDictionary<Type,object> cache;
        static ViewAReportSpecs.AnItem the_item;
        static IFetchAReport<ViewAReportSpecs.AnItem> original;
        static IDetermineIfACacheItemNeedsToBeRefreshed cache_refresh_policy;
      } 
        
      static IContainRequestDetails request;
      static ViewAReportSpecs.AnItem result;
    }
  }
}

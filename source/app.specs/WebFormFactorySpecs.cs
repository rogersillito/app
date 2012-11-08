 using System.Web;
 using System.Web.UI;
 using Machine.Specifications;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(WebFormFactory))]  
  public class WebFormFactorySpecs
  {
    public abstract class concern : Observes<ICreateViewsForReports,
                                      WebFormFactory>
    {
        
    }

   
    public class when_creating_the_page_for_a_report : concern
    {
      Establish c = () =>
      {
        report = new ViewAReportSpecs.AnItem();
        the_view_that_can_display_the = fake.an<IDisplayA<ViewAReportSpecs.AnItem>>();
        the_path = "blah.asxp";
        page_path_registry = depends.on<IFindPathsToPages>();
        depends.on<ICreatePageInstances>((path,page_type) =>
        {
          path.ShouldEqual(the_path);
          page_type.ShouldEqual(typeof(IDisplayA<ViewAReportSpecs.AnItem>));
          return the_view_that_can_display_the;
        });

        page_path_registry.setup(x => x.get_the_path_to_the_page_that_displays<ViewAReportSpecs.AnItem>()).Return(the_path);
      };


      Because b = () =>
        result = sut.create_view_that_can_display(report);


      It should_return_the_page_that_can_view_the_report = () =>
        result.ShouldEqual(the_view_that_can_display_the);

      It should_populate_the_view_with_its_model = () =>
        the_view_that_can_display_the.report.ShouldEqual(report);


      static IHttpHandler result;
      static IDisplayA<ViewAReportSpecs.AnItem> the_view_that_can_display_the;
      static ViewAReportSpecs.AnItem report;
      static IFindPathsToPages page_path_registry;
      static string the_path;
    }
  }
}

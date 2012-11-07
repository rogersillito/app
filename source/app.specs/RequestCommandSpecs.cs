﻿using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(RequestCommand))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
      };

      Because b = () =>
        sut.can_run(request);


      It  = () => 

      static IContainRequestDetails request;
    }
  }
}
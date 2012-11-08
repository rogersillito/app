using Machine.Specifications;
using Rhino.Mocks;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

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
                decides_which_kind_of_requests_a_command_can_run = depends.on<IDecideWhichKindOfRequestsACommandCanRun>();
                request = fake.an<IContainRequestDetails>();
                decides_which_kind_of_requests_a_command_can_run.setup(x => x.CanHandleRequest(Arg<IContainRequestDetails>.Is.Anything)).Return(true);
            };

            Because b = () =>
              sut.can_run(request);

            It should_delegate_the_decision_on_whether_the_command_can_run_the_request = () =>
                decides_which_kind_of_requests_a_command_can_run.received(
                    x => x.CanHandleRequest(Arg<IContainRequestDetails>.Is.Anything));

            static IContainRequestDetails request;
        }

        static IDecideWhichKindOfRequestsACommandCanRun decides_which_kind_of_requests_a_command_can_run;
    }
}
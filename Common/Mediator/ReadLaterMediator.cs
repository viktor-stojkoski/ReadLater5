namespace Shared.Mediator
{
    using MediatR;

    public class ReadLaterMediator : Mediator
    {
        public ReadLaterMediator(ServiceFactory serviceFactory)
            : base(serviceFactory) { }
    }
}

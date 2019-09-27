using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTry
{
    //Request are used to execute commands being the Command part of the CQRS
    public class PingCommand : IRequest<string>
    {
        public PingCommand(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    //Just one handler per request.
    public class PingCommandHandler : IRequestHandler<PingCommand, string>
    {
        public Task<string> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() => $"Request Handled by {nameof(PingCommandHandler)} -> {request.Message}");
        }
    }

    //Validators can only be applied on request/commands, but not notifications.
    public class PingCommandValidator : AbstractValidator<PingCommand>
    {
        public PingCommandValidator()
        {
            RuleFor(x => x.Message).MaximumLength(5).NotEmpty();
        }
    }
}
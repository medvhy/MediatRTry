using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTry
{
    public class Ping : IRequest<string>
    {
        public Ping(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.Run(() => $"Request Handled by {nameof(PingHandler)} -> {request.Message}");
        }
    }
}
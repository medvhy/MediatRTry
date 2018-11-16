using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRTry
{
    public class SomeEvent : INotification
    {
        public SomeEvent(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class Handler1 : INotificationHandler<SomeEvent>
    {
        private readonly ILogger<Handler1> _logger;

        public Handler1(ILogger<Handler1> logger)
        {
            _logger = logger;
        }

        public async Task Handle(SomeEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => _logger.LogWarning($"Notification Handled by Handler1: {notification.Message}"));
        }
    }

    public class Handler2 : INotificationHandler<SomeEvent>
    {
        private readonly ILogger<Handler2> _logger;

        public Handler2(ILogger<Handler2> logger)
        {
            _logger = logger;
        }

        public async Task Handle(SomeEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => _logger.LogWarning($"Notification Handled by Handler2: {notification.Message}"));
        }
    }

    public class SomeEventCommandValidator : AbstractValidator<SomeEvent>
    {
        public SomeEventCommandValidator()
        {
            RuleFor(x => x.Message).MaximumLength(5).NotEmpty();
        }
    }
}

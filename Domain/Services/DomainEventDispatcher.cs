using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Services
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public DomainEventDispatcher(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public async Task DispatchEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                //_logger.LogInformation($"Dispatching domain event: {EventType}", domainEvent.EventType);
                _logger.LogInformation("Dispatching domain event");

                await _mediator.Publish(domainEvent);
            }
        }
    }
}

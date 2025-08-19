using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Domain.CommandHandlers;

public class TransferCommandHandler(IEventBus _bus) : IRequestHandler<CreateTransferCommand, bool>
{
    public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
    {
        _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));
        return Task.FromResult(true);
    }
}

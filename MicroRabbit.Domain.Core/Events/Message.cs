using MediatR;

namespace MicroRabbit.Domain.Core.Events;

public abstract class Message : IRequest<bool>
{
    public string MessegaType { get; protected set; }
    protected Message()
    {
        MessegaType = GetType().Name;
    }   
}

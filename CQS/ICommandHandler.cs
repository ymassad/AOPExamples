namespace CQS
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
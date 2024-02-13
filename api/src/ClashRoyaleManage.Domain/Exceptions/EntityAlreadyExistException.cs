namespace ClashRoyaleManager.Domain.Exceptions;

public class EntityAlreadyExistException : Exception
{
    public EntityAlreadyExistException(string? message) : base(message){ }
}
namespace ClashRoyaleManager.Domain.Exceptions;

public class EntityDoesNotExistException : Exception
{
    public EntityDoesNotExistException(string? message) : base(message){ }
}
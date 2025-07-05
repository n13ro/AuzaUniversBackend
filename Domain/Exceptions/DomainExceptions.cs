

namespace Domain.Exceptions
{
    public abstract class DomainExceptions : Exception
    {
        protected DomainExceptions(string msg) : base(msg) { }
    }

    public class ValidationException : DomainExceptions
    {
        public ValidationException(string msg) : base(msg) { }
    }

    public class EntityNotFoundException : DomainExceptions
    {
        public EntityNotFoundException(string entity, int id) : base($"{entity} with id {id} was not found") { }
    }
}

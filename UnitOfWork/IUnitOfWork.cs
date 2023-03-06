using Repositories;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IContactoRepository Contacto { get; }

    }
}

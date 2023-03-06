using Repositories;
using UnitOfWork;

namespace DataAccess
{
    public class ChallengeUnitOfWork : IUnitOfWork
    {
        public ChallengeUnitOfWork(string connectionString, string _apiFacturaElectronica)
        {
            Contacto = new ContactoRepository(connectionString);

        }
        public IContactoRepository Contacto { get; private set; }

    }
}

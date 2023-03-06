using Models;
using System;

namespace Repositories
{
    public interface IContactoRepository : IRepository<Contacto>
    {
        ResultPagination<Contacto> GetAllContacto(int page, int rows);
    }
}


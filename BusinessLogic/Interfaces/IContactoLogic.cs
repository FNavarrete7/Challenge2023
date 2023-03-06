using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IContactoLogic
    {
        Contacto GetById(int id);
        //IEnumerable<Contacto> GetList();
        int Insert(Contacto Contacto, Int32 usuario);
        bool Update(Contacto Contacto, Int32 usuario);
        bool Delete(Contacto Contacto, Int32 usuario);
        ResultPagination<Contacto> GetAllContacto(int page, int rows);
    }
}

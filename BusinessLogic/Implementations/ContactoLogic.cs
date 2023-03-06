using BusinessLogic.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace BusinessLogic.Implementations
{
    public class ContactoLogic : IContactoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Contacto Contacto, int usuario)
        {
            try
            {
                bool resp = _unitOfWork.Contacto.Delete(Contacto);


                return resp;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ResultPagination<Contacto> GetAllContacto(int page, int rows)
        {
            return _unitOfWork.Contacto.GetAllContacto(page, rows);
        }

        public Contacto GetById(int id)
        {
            return _unitOfWork.Contacto.GetById(id);
        }

        public int Insert(Contacto Contacto, int usuario)
        {
            try
            {
                int resp = _unitOfWork.Contacto.Insert(Contacto);

                return resp;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Update(Contacto Contacto, int usuario)
        {
            try
            {
                bool resp = _unitOfWork.Contacto.Update(Contacto);
                return resp;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

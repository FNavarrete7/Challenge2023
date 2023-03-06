using System;
using System.Collections.Generic;

namespace Models
{
    public class ResultPagination<T>
    {
        public List<T> ListaResultado { get; set; }
        public Int32 CantidadResultado { get; set; }
    }
}

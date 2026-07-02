using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Utilidades
{
    public class Response<T>
    {
        public bool Status { get; set; }

        public T value { get; set; }

        public string msg { get; set; }
    }
}

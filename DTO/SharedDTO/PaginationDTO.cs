using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_DTO.SharedDTO
{
    public class PaginationDTO<T>
    {
        public int Total { get; set; }

        public List<T> Data { get; set; } = new();
    }
}

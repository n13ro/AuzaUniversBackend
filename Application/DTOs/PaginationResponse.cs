﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ViewModel
{
    public class PagedResult<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public List<T> Data { get; set; } = new List<T>();

    }
}

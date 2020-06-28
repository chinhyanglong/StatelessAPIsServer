using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Services.Common
{
    public class PaginatorUtils
    {
        public static readonly int DEFAULT_PAGE = 1;
        public static readonly int DEFAULT_PAGING_SIZE = 20;
        public static readonly string DEFAULT_SORT_ORDER = "asc";
        public static readonly string DESC_SORT_ORDER = "desc";

        public static int GetPageNumber(int? page)
        {
            if (page == null || page < 1)
            {
                page = DEFAULT_PAGE;
            }
            return (int)page;
        }

        public static int GetPageSize(int? size)
        {
            if (size == null || size < 1)
            {
                size = DEFAULT_PAGING_SIZE;
            }
            return (int)size;
        }

        public static int GetStartRow(int page, int size)
        {
            return (page - 1) * size + 1;
        }

        public static int GetEndRow(int page, int size)
        {
            return (page - 1) * size + size;
        }

        public static int GetSkipRow(int page, int size)
        {
            return GetStartRow(page, size) - 1;
        }

        public static string GetSortOrder(string sortOrder)
        {
            return sortOrder ?? DEFAULT_SORT_ORDER;
        }

    }
}

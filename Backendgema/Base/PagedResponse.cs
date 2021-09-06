using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backendgema.Base
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public String FirstPage { get; set; }
        public String LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public String NextPage { get; set; }
        public String PreviousPage { get; set; }
        public T data { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.data = data;
        }
        
    }
}

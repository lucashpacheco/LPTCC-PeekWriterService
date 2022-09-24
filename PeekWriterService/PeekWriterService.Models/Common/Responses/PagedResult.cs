using System.Collections.Generic;

namespace PeekWriterService.Models.Common.Responses
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Result { get; set; }
    }
}

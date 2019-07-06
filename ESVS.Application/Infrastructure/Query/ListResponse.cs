using System.Collections.Generic;

namespace ESVS.Application.Infrastructure.Query
{
    public class ListResponse<T> where T : class
    {
        public ICollection<T> Items { get; set; }
        public string Sort { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public int PagesCount
        {
            get
            {
                var pagesCount = TotalItemsCount / PageSize;
                if (TotalItemsCount % PageSize != 0)
                    pagesCount++;
                return pagesCount;
            }
        }
    }
}

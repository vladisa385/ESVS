using System.Collections.Generic;

namespace ViewModel
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
                int pagesCount = TotalItemsCount / PageSize;
                if (TotalItemsCount % PageSize != 0)
                    pagesCount++;
                return pagesCount;
            }
        }
    }
}

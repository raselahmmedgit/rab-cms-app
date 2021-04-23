using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Model;
using System.Collections.Generic;

namespace PlacovuCMS.ViewModel
{
    public class PageList
    {
        public IEnumerable<Page> page { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public int allTotalPage { get; set; }
        public int activeTotalPage { get; set; }
        public int inactiveTotalPage { get; set; }
        public string searchText { get; set; }
        public int? status { get; set; }
    }
}

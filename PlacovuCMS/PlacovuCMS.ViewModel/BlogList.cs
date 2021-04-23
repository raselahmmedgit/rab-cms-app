using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Model;
using System.Collections.Generic;

namespace PlacovuCMS.ViewModel
{
    public class BlogList
    {
        public IEnumerable<Blog> blog { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public int allTotal { get; set; }
        public int activeTotal { get; set; }
        public int inactiveTotal { get; set; }
        public string searchText { get; set; }
        public int? status { get; set; }
    }
}

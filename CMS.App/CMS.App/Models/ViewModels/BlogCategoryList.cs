﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.App.Infrastructure;
using CMS.App.Models;

namespace CMS.App.Models.ViewModels
{
    public class BlogCategoryList
    {
        public IEnumerable<BlogCategory> blogCategory { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public int allTotal { get; set; }
        public int activeTotal { get; set; }
        public int inactiveTotal { get; set; }
        public string searchText { get; set; }
        public int? status { get; set; }
    }
}

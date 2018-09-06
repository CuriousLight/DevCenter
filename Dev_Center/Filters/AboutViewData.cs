using Dev_Center.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Center.Filters
{
    public class AboutViewData : ViewDataBase
    {
        public AboutViewData(SiteMasterViewData siteMaster)
        {
            base.SiteMasterViewData = siteMaster;
        }

        public string Text { get; set; }
    }
}

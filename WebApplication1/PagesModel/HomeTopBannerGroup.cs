using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.PagesModel
{
    public class HomeTopBannerGroup
    {
        public HomeTopBannerGroup()
        {
            List = new List<HomeTopBanner>();
        }

        public List<HomeTopBanner> List
        {
            get;
            set;
        }
    }
}
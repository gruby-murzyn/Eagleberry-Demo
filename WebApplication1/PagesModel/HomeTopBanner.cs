using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.PagesModel
{
    public class HomeTopBanner
    {
        public HomeTopBanner(string image, HomeTopBannerSize size)
        {
            Image = image;
            Size = size;
        }

        public string Image
        {
            get;
            set;
        }

        public HomeTopBannerSize Size
        {
            get;
            set;
        }
    }

    public enum HomeTopBannerSize
    {
        Small,
        Medium,
        Big
    }
}
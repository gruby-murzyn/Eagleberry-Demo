using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace WebApplication1.PagesModel
{
    public static class HomeTopBannerRenderer
    {

        private static HomeTopBannerSize GetSizeByFileName(string fileName)
        {
            if (fileName.ToUpper().StartsWith("S_"))
                return HomeTopBannerSize.Small;
            else if (fileName.ToUpper().StartsWith("M_"))
                return HomeTopBannerSize.Medium;
            else if (fileName.ToUpper().StartsWith("B_"))
                return HomeTopBannerSize.Big;
            else
                return HomeTopBannerSize.Small;
        }


        public static List<object> GetBanners(IEnumerable<IPublishedContent> mediaList)
        {
            List<object> resultList = new List<object>();
            int i = 0;
            for (; i< mediaList.Count(); i++)
            {
                string fileName = mediaList.ElementAt(i).Name;
                HomeTopBannerSize size= GetSizeByFileName(fileName);
                if (size != HomeTopBannerSize.Small)
                    resultList.Add(new HomeTopBanner(mediaList.ElementAt(i).Url, size));
                else
                {
                    if (i == mediaList.Count() - 1)
                        throw new Exception("Small banner must be paired with another small banner element");
                    IPublishedContent nextElement = mediaList.ElementAt(i + 1);
                    HomeTopBannerSize nextElementSize = GetSizeByFileName(nextElement.Name);
                    if (nextElementSize!= HomeTopBannerSize.Small)
                        throw new Exception("Cannot group top banner element with different sizes");
                    HomeTopBannerGroup group = new HomeTopBannerGroup();
                    group.List.Add(new HomeTopBanner(mediaList.ElementAt(i).Url, size));
                    group.List.Add(new HomeTopBanner(nextElement.Url, nextElementSize));
                    resultList.Add(group);
                    i++;
                }

            }

            return resultList;
        }
    }
}
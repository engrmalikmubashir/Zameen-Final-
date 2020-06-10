using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zameen.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem()
            {
                Text = "-- Select --",
                Value = "0"
            };
            list.Add(sli);
            foreach (var item in Items)
            {
                sli = new SelectListItem()
                {
                    Text = item.GetPropertyValue("Name"),
                    Value = item.GetPropertyValue("Id")
                };
                list.Add(sli);
            }

            return list;
        }

    }
}

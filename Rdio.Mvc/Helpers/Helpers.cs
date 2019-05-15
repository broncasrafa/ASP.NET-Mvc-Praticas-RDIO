using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rdio.Mvc.Helpers
{
    public static class Helpers
    {
        public static IEnumerable<IEnumerable<T>> SplitList<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;

            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();

            return splits;
        }
    }
}

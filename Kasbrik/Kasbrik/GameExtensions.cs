using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasbrik
{
    public static class GameExtensions
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }
    }
}

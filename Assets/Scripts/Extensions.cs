using Reckless.Items;
using System.Collections.Generic;
using System.Linq;

namespace Reckless
{
    public static class Extensions
    {
        public static string[] BuildArrayOfItems(this List<ItemObject> list)
        {
            List<string> names = new (){ "None" };
            if (list == null) return names.ToArray();
            names.AddRange(list.Select(x => x._itemName));
            return names.ToArray();
        }
    }
}

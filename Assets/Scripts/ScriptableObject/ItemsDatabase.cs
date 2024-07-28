using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    [CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Reckless/ItemsDatabase")]
    public class ItemsDatabase : ScriptableObject
    {
        [SerializeField] List<ItemObject> _items;

        public ItemObject GetItem(string id) => new (_items.Find(x => x._itemID == id));
        public ItemObject GetItem(int index) => new (_items[index]);
        public List<ItemObject> GetAllItems() => _items;
    }
}

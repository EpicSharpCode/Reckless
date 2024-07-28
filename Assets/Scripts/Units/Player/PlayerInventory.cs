using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEditor.Progress;

namespace Reckless.Units
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] int _maxItems = 10;
        [SerializeField] List<ItemObject> _items;

        public bool AddItem(ItemObject item) 
        {
            if(_items.Count >= _maxItems) { return false; }

            _items.Add(new ItemObject(item));
            return true;
        }
        public bool RemoveItem(ItemObject item)
        {
            if(!_items.Contains(item)) { return false; }

            _items.Remove(item);
            return true;
        }
        public bool RemoveItem(string name)
        {
            return RemoveItem(_items.Find(x => x.itemName == name));
        }
    }
}

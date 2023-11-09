using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace Reckless.Unit
{
    public class RL_Player_Inventory : MonoBehaviour
    {
        [SerializeField] int maxItems = 10;
        [SerializeField] List<RL_ItemObject> items;

        public bool AddItem(RL_ItemObject item) 
        {
            if(items.Count >= maxItems) { return false; }

            items.Add(new RL_ItemObject(item));
            return true;
        }
        public bool RemoveItem(RL_ItemObject item)
        {
            if(!items.Contains(item)) { return false; }

            items.Remove(item);
            return true;
        }
        public bool RemoveItem(string name)
        {
            return RemoveItem(items.Find(x => x.GetName() == name));
        }
    }
}

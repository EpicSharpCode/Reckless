using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Reckless/ItemsDatabase")]
    public class RL_Items_Database : ScriptableObject
    {
        [SerializeField] List<RL_ItemObject> items;

        public RL_ItemObject GetItem(string _ID) => new (items.Find(x => x.itemID == _ID));
    }
}

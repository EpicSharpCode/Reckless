using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Hotline/ItemsDatabase")]
    public class RL_Items_Database : ScriptableObject
    {
        [SerializeField] List<RL_ItemObject> items;

        public RL_ItemObject GetItem(string _name) => new RL_ItemObject(items.Find(x => x.GetName() == _name));
    }
}

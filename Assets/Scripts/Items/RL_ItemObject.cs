using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [System.Serializable]
    public class RL_ItemObject
    {
        [SerializeField] public string itemName;
        [SerializeField] public string itemID;
        [SerializeField] public string localizedName;
        [SerializeField] public float value;
        public string ItemName => itemName;
        public string ItemID => itemID;
        public string LocalizedName => localizedName;
        public float Value => value;

        public RL_ItemObject(RL_ItemObject _itemObject)
        {
            itemName = _itemObject.itemName;
            localizedName = _itemObject.localizedName;
            value = _itemObject.value;
        }
    }
}

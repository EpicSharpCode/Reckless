using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [System.Serializable]
    public class RL_ItemObject
    {
        [SerializeField] string itemName;
        [SerializeField] string localizedName;
        [SerializeField] float value;

        public RL_ItemObject(RL_ItemObject _itemObject)
        {
            itemName = _itemObject.itemName;
            localizedName = _itemObject.localizedName;
            value = _itemObject.value;
        }

        public string GetName() => itemName;
        public string GetLocalizedName() => localizedName;
    }
}

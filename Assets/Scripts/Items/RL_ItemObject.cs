using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Items
{
    [System.Serializable]
    public class RL_ItemObject
    {
        [field:SerializeField] public string ItemName { get; private set; }
        [field: SerializeField] public string LocalizedName { get; private set; }
        [field:SerializeField] public float Value { get; private set; }

        public RL_ItemObject(RL_ItemObject _itemObject)
        {
            ItemName = _itemObject.ItemName;
            LocalizedName = _itemObject.LocalizedName;
            Value = _itemObject.Value;
        }
    }
}

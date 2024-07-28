using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    [System.Serializable]
    public class ItemObject
    {
        [SerializeField] public string _itemName;
        [SerializeField] public string _itemID;
        [SerializeField] public string _localizedName;
        [SerializeField] public float _value;
        
        public string itemName => _itemName;
        public string itemID => _itemID;
        public string localizedName => _localizedName;
        public float value => _value;

        public ItemObject(ItemObject itemObject)
        {
            _itemName = itemObject._itemName;
            _localizedName = itemObject._localizedName;
            _value = itemObject._value;
        }
    }
}

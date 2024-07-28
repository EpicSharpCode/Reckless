using Reckless.Units;
using Reckless.Entities;
using Reckless.Items;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Entities
{
    public class ItemBox : BoxEntity
    {
        ItemObject _itemObject;

        public ItemBox(ItemObject itemObject) => _itemObject = itemObject;
        public override List<ItemObject> boxContent => GameVariables.GetAllItems();
        public override string boxContentName => "Item";


        void Start() => Setup(_selectedIndex);
        public override void Setup(int itemIndex) 
        { 
            if(itemIndex < 1) return;
            _itemObject = GameVariables.GetItem(itemIndex - 1);
            _nameText.text = _itemObject.localizedName;
        }

        public override void Pickup(Unit player)
        {
            if(player is not Player) { return; }
            if(_itemObject == null) 
            {
                Debug.LogError("Item wasn't found at box");
                return;
            }
            bool status = player.GetComponent<PlayerInventory>().AddItem(_itemObject);
            if (status) Destroy(gameObject);
        }
    }
}

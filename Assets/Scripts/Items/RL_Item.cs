using Reckless.Environment;
using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Reckless.Items
{
    public class RL_Item : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] internal TMP_Text itemText;
        [SerializeField] internal string itemName;
        
        RL_ItemObject itemObject;

        private void Start() => Setup(itemName);

        public virtual void Setup(string _itemName) 
        { 
            itemObject = RL_GlobalVariables.GetItem(_itemName);
            itemText.text = itemObject.LocalizedName;
        }

        public virtual void Pickup(RL_Unit player)
        {
            bool status = player.GetComponent<RL_Player_Inventory>().AddItem(itemObject);
            if (status) Destroy(gameObject);
        }
    }
}

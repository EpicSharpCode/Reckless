using Reckless.Unit;
using Reckless.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    public class RL_Item : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] internal TMP_Text itemText;
        [SerializeField] internal string itemID;
        
        RL_ItemObject itemObject;

        private void Start() => Setup(itemID);

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

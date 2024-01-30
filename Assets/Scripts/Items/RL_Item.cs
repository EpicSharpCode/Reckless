using Reckless.Unit;
using Reckless.Entities;
using TMPro;
using UnityEngine;

namespace Reckless.Items
{
    public class RL_Item : MonoBehaviour, RL_IPickupable
    {
        [SerializeField] internal TMP_Text itemText;
        [HideInInspector] public int selectedItemIndex = 0;
        
        RL_ItemObject itemObject;

        void Start() => Setup(selectedItemIndex);
        public virtual void Setup(int _itemIndex) 
        { 
            if(_itemIndex < 0) return;
            itemObject = RL_Game_Variables.GetItem(_itemIndex - 1);
            itemText.text = itemObject.LocalizedName;
        }

        public virtual void Pickup(RL_Unit player)
        {
            if(itemObject == null) return;
            bool status = player.GetComponent<RL_Player_Inventory>().AddItem(itemObject);
            if (status) Destroy(gameObject);
        }
    }
}

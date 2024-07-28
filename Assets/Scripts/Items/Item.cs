using Reckless.Units;
using Reckless.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Items
{
    public class Item : MonoBehaviour, IPickupable
    {
        [SerializeField] internal TMP_Text _itemText;
        [HideInInspector] public int _selectedItemIndex;
        
        ItemObject _itemObject;

        void Start() => Setup(_selectedItemIndex);
        public virtual void Setup(int itemIndex) 
        { 
            if(itemIndex < 0) return;
            _itemObject = GameVariables.GetItem(itemIndex - 1);
            _itemText.text = _itemObject.localizedName;
        }

        public virtual void Pickup(Unit player)
        {
            if(_itemObject == null) return;
            bool status = player.GetComponent<PlayerInventory>().AddItem(_itemObject);
            if (status) Destroy(gameObject);
        }
    }
}

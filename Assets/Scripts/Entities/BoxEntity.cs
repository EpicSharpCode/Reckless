using Reckless.Items;
using Reckless.Units;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Reckless.Entities
{
    public abstract class BoxEntity : MonoBehaviour, IPickupable
    {
        [HideInInspector] [SerializeField] protected int _selectedIndex;

        public abstract List<ItemObject> boxContent { get; }
        public abstract string boxContentName { get; }
        public int selectedIndex
        {
            get => _selectedIndex;
            set => _selectedIndex = value;
        }

        [SerializeField] protected TMP_Text _nameText;
        public abstract void Pickup(Unit unit);
        public abstract void Setup(int itemIndex);
    }
}

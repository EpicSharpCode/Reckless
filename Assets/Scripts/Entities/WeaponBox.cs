using Reckless.Items;
using Reckless.Units;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Reckless.Entities
{
    public class WeaponBox : BoxEntity
    {
        WeaponObject _weaponObject;

        public WeaponBox(WeaponObject weaponObject) => _weaponObject = weaponObject;
        
        public override List<ItemObject> boxContent => GameVariables.GetAllWeapons().Cast<ItemObject>().ToList();
        public override string boxContentName => "Weapon";

        
        void Start() => Setup(_selectedIndex);
        public override void Setup(int itemIndex)
        {
            if(itemIndex < 1) return;
            _weaponObject = GameVariables.GetWeapon(itemIndex - 1);
            _nameText.text = _weaponObject.localizedName;
        }
        public override void Pickup(Unit player)
        {
            if(player is not Player) { return; }
            if (_weaponObject == null)
            {
                Debug.LogError("Weapon wasn't found at box");
                return;
            }
            var playerBelt = player.GetComponent<PlayerBelt>();
            var status = playerBelt.AddWeapon(_weaponObject);
            if (status) Destroy(gameObject);
        }
    }
}

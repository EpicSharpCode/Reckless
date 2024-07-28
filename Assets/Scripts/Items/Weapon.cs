using Reckless.Units;

namespace Reckless.Items
{
    public class Weapon : Item
    {
        WeaponObject _weaponObject;

        public Weapon(WeaponObject weaponObject)
        {
            this._weaponObject = weaponObject;
        }

        public override void Setup(int itemIndex)
        {
            if(itemIndex < 0) return;
            _weaponObject = GameVariables.GetWeapon(itemIndex - 1);
            _itemText.text = _weaponObject.localizedName;
        }
        public override void Pickup(Unit player)
        {
            if(!(player is Player)) { return; }
            var playerBelt = player.GetComponent<PlayerBelt>();
            var status = playerBelt.AddWeapon(_weaponObject);
            if (status) Destroy(gameObject);
        }
    }
}

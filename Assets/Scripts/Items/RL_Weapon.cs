using Reckless.Unit;

namespace Reckless.Items
{
    public class RL_Weapon : RL_Item
    {
        RL_WeaponObject weaponObject;

        public RL_Weapon(RL_WeaponObject _weaponObject)
        {
            weaponObject = _weaponObject;
        }

        public override void Setup(string _itemName)
        {
            weaponObject = RL_GlobalVariables.GetWeapon(_itemName);
            itemText.text = weaponObject.LocalizedName;
        }
        public override void Pickup(RL_Unit player)
        {
            if(!(player is RL_Player)) { return; }
            var playerBelt = player.GetComponent<RL_Player_Belt>();
            var status = playerBelt.AddWeapon(weaponObject);
            if (status) Destroy(gameObject);
        }
    }
}

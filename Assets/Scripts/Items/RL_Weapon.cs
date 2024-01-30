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

        public override void Setup(int _itemIndex)
        {
            if(_itemIndex < 0) return;
            weaponObject = RL_Game_Variables.GetWeapon(_itemIndex - 1);
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

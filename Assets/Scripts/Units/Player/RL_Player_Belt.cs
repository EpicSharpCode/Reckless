using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace Reckless.Unit
{
    public class RL_Player_Belt : MonoBehaviour
    {
        [SerializeField] RL_WeaponObject currentWeapon;
        [SerializeField] List<RL_WeaponObject> weapons;
        [SerializeField] int maxWeapons = 4;
        
        [SerializeField] Transform shootSource;

        Coroutine makeFireCorutine = null;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if(makeFireCorutine != null) { return; }
                makeFireCorutine = StartCoroutine(MakeFire());
            }
        }

        public IEnumerator MakeFire()
        {
            if (currentWeapon == null) { yield break; }
            var weaponPreference = currentWeapon.WeaponPrefrence;
            if (weaponPreference == null) { yield break; }

            if (Input.GetMouseButton(0))
            {
                Vector3 weaponOrigin = shootSource.position;
                Vector3 direction = shootSource.forward;

                Debug.Log($"Fire with fire rate: {weaponPreference.FireRate}");

                var bullet = Instantiate(weaponPreference.BulletPrefab);
                bullet.transform.position = weaponOrigin;
                bullet.Setup(Random.Range(weaponPreference.DamageMin, weaponPreference.DamageMax));

                bullet.GetComponent<Rigidbody>().AddForce(direction * currentWeapon.WeaponPrefrence.BulletPower);


            }
            yield return new WaitForSeconds(weaponPreference.FireRate);
            makeFireCorutine = null;
        }


        public bool AddWeapon(RL_WeaponObject weaponObject)
        {
            if (weapons.Count >= maxWeapons) { return false; }

            var weapon = new RL_WeaponObject(weaponObject);
            weapons.Add(weapon);
            currentWeapon = weapon;
            return true;
        }
        public bool RemoveWeapon(RL_WeaponObject weaponObject)
        {
            if (!weapons.Contains(weaponObject)) { return false; }

            weapons.Remove(weaponObject);
            return true;
        }
        public bool RemoveWeapon(string name)
        {
            return RemoveWeapon(weapons.Find(x => x.ItemName == name));
        }
    }
}

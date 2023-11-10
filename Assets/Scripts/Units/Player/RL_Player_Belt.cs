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

        [SerializeField] float weaponBulletsOffset = 0.6f;
        [SerializeField] float weaponYOffset = 1;

        Coroutine makeFireCorutine = null;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                /* Debug
                Vector3 weaponOrigin = new Vector3(
                    transform.position.x,
                    transform.position.y + weaponYOffset, 
                    transform.position.z);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit = Physics.RaycastAll(ray)[0];
                Vector3 hit = raycastHit.point;
                hit.y = weaponOrigin.y;
                Vector3 direction = (hit - weaponOrigin).normalized;
                Debug.DrawRay(weaponOrigin + (direction * weaponBulletsOffset), direction, Color.red, 5);
                */


                if(makeFireCorutine != null) { return; }
                makeFireCorutine = StartCoroutine(MakeFire());
            }
        }

        public IEnumerator MakeFire()
        {
            if (currentWeapon == null) { yield break; }
            var weaponPreference = currentWeapon.GetWeaponPrefrence();
            if (weaponPreference == null) { yield break; }

            if (Input.GetMouseButton(0))
            {
                Vector3 weaponOrigin = new Vector3(
                    transform.position.x,
                    transform.position.y + weaponYOffset,
                    transform.position.z);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] raycastHits = Physics.RaycastAll(ray);
                if(raycastHits.Length == 0) yield break;
                RaycastHit raycastHit = raycastHits[0];
                Vector3 hit = raycastHit.point;
                hit.y = weaponOrigin.y;
                Vector3 direction = (hit - weaponOrigin).normalized;

                Debug.Log($"Fire with fire rate: {weaponPreference.GetFireRate()}");

                var bullet = Instantiate(weaponPreference.GetBulletPrefab());
                bullet.transform.position = weaponOrigin + direction;
                bullet.Setup(Random.Range(weaponPreference.GetDamageMin(), weaponPreference.GetDamageMax()));

                bullet.GetComponent<Rigidbody>().AddForce(direction * 1000);


            }
            yield return new WaitForSeconds(weaponPreference.GetFireRate());
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
            return RemoveWeapon(weapons.Find(x => x.GetName() == name));
        }
    }
}

using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEditor.Progress;

namespace Reckless.Unit
{
    public class RL_Player_Belt : MonoBehaviour
    {
        [SerializeField] RL_WeaponObject _currentWeapon;
        [SerializeField] List<RL_WeaponObject> _weapons;
        [SerializeField] int _maxWeapons = 4;

        [SerializeField] GameObject _weaponRepresentationHolder;
        [SerializeField] RL_WeaponRepresentation _currentWeaponRepresentation;
        

        Coroutine _makeFireCorutine = null;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if(_makeFireCorutine != null) { return; }
                _makeFireCorutine = StartCoroutine(MakeFire());
            }
        }

        public IEnumerator MakeFire()
        {
            if (_currentWeapon == null) { yield break; }
            var weaponPreference = _currentWeapon.WeaponPrefrence;
            if (weaponPreference == null) { yield break; }

            if (Input.GetMouseButton(0))
            {
                Vector3 weaponOrigin = _currentWeaponRepresentation.ShootSource.position;
                Vector3 direction = _currentWeaponRepresentation.ShootSource.forward;

                Debug.Log($"Fire with fire rate: {weaponPreference.FireRate}");

                var bullet = Instantiate(weaponPreference.BulletPrefab);
                bullet.transform.position = weaponOrigin;
                bullet.Setup(Random.Range(weaponPreference.DamageMin, weaponPreference.DamageMax));

                bullet.GetComponent<Rigidbody>().AddForce(direction * _currentWeapon.WeaponPrefrence.BulletPower);


            }
            yield return new WaitForSeconds(weaponPreference.FireRate);
            _makeFireCorutine = null;
        }


        public bool AddWeapon(RL_WeaponObject weaponObject)
        {
            if (_weapons.Count >= _maxWeapons) { return false; }

            var weapon = new RL_WeaponObject(weaponObject);
            _weapons.Add(weapon);
            SelectCurrentWeapon(weaponObject);
            return true;
        }
        public bool RemoveWeapon(RL_WeaponObject weaponObject)
        {
            if (!_weapons.Contains(weaponObject)) { return false; }

            _weapons.Remove(weaponObject);
            return true;
        }

        void SelectCurrentWeapon(RL_WeaponObject weaponObject)
        {
            foreach (Transform tr in _weaponRepresentationHolder.transform)
            {
                Destroy(tr);
            }
            _currentWeapon = weaponObject;
            _currentWeaponRepresentation = Instantiate(weaponObject.WeaponPrefrence.WeaponRepresentationPrefab, _weaponRepresentationHolder.transform);
        }
        public bool RemoveWeapon(string name)
        {
            return RemoveWeapon(_weapons.Find(x => x.ItemName == name));
        }
    }
}

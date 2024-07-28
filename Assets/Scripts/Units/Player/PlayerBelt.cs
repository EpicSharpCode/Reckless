using Reckless.Items;
using System.Collections;
using System.Collections.Generic;
using Reckless.Entities;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEditor.Progress;

namespace Reckless.Units
{
    public class PlayerBelt : MonoBehaviour
    {
        [SerializeField] WeaponObject _currentWeapon;
        [SerializeField] List<WeaponObject> _weapons;
        [SerializeField] int _maxWeapons = 4;

        [SerializeField] GameObject _weaponRepresentationHolder;
        [SerializeField] WeaponRepresentation _currentWeaponRepresentation;
        

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
            var weaponPreference = _currentWeapon.weaponPrefrence;
            if (weaponPreference == null) { yield break; }

            if (Input.GetMouseButton(0))
            {
                Vector3 weaponOrigin = _currentWeaponRepresentation.shootSource.position;
                Vector3 direction = _currentWeaponRepresentation.shootSource.forward;

                Debug.Log($"Fire with fire rate: {weaponPreference.fireRate}");

                var bullet = Instantiate(weaponPreference.bulletPrefab);
                bullet.transform.position = weaponOrigin;
                bullet.Setup(Random.Range(weaponPreference.damageMin, weaponPreference.damageMax));

                bullet.GetComponent<Rigidbody>().AddForce(direction * _currentWeapon.weaponPrefrence.bulletPower);


            }
            yield return new WaitForSeconds(weaponPreference.fireRate);
            _makeFireCorutine = null;
        }


        public bool AddWeapon(WeaponObject weaponObject)
        {
            if (_weapons.Count >= _maxWeapons) { return false; }

            var weapon = new WeaponObject(weaponObject);
            _weapons.Add(weapon);
            SelectCurrentWeapon(weaponObject);
            return true;
        }
        public bool RemoveWeapon(WeaponObject weaponObject)
        {
            if (!_weapons.Contains(weaponObject)) { return false; }

            _weapons.Remove(weaponObject);
            return true;
        }

        void SelectCurrentWeapon(WeaponObject weaponObject)
        {
            foreach (Transform tr in _weaponRepresentationHolder.transform)
            {
                Destroy(tr);
            }
            _currentWeapon = weaponObject;
            _currentWeaponRepresentation = Instantiate(weaponObject.weaponPrefrence.weaponRepresentationPrefab, _weaponRepresentationHolder.transform);
        }
        public bool RemoveWeapon(string weaponName)
        {
            return RemoveWeapon(_weapons.Find(x => x.itemName == weaponName));
        }
    }
}

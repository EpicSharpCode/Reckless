using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Enemy_Belt : MonoBehaviour
    {
        [SerializeField] RL_WeaponPrefrence weaponPreference;
        [SerializeField] float weaponYOffset = 1;

        RL_Enemy thisEnemy;

        Coroutine makeFireCorutine = null;

        private void Awake()
        {
            thisEnemy = GetComponent<RL_Enemy>();
        }

        // Update is called once per frame
        void Update()
        {
            if (makeFireCorutine != null) { return; }
            makeFireCorutine = StartCoroutine(MakeFire());
        }


        public IEnumerator MakeFire()
        {
            if (weaponPreference == null) { yield break; }

            Vector3 weaponOrigin = new Vector3(
                transform.position.x,
                transform.position.y + weaponYOffset,
                transform.position.z);
            var goal = thisEnemy.GetGoal();
            if(goal == null) yield break;
            var goalPos = thisEnemy.GetGoal().transform.position;
            goalPos.y = weaponOrigin.y;
            Vector3 direction = (goalPos - weaponOrigin).normalized;

            Debug.Log($"Fire with fire rate: {weaponPreference.GetFireRate()}");

            var bullet = Instantiate(weaponPreference.GetBulletPrefab());
            bullet.transform.position = weaponOrigin + direction;
            bullet.Setup(Random.Range(weaponPreference.GetDamageMin(), weaponPreference.GetDamageMax()));

            bullet.GetComponent<Rigidbody>().AddForce(direction * 1000);

            yield return new WaitForSeconds(weaponPreference.GetFireRate());
            makeFireCorutine = null;
        }
    }
}

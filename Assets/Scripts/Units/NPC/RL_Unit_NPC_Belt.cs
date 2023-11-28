using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit.AI
{
    public class RL_Unit_NPC_Belt : MonoBehaviour
    {
        [SerializeField] RL_WeaponPreference weaponPreference;
        [SerializeField] float weaponYOffset = 1;

        RL_Unit_NPC thisNPC;

        Coroutine makeFireCorutine = null;

        private void Awake()
        {
            thisNPC = GetComponent<RL_Unit_NPC>();
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
            var goal = thisNPC.Goal;
            if(goal == null) yield break;
            var goalPos = thisNPC.Goal.transform.position;
            goalPos.y = weaponOrigin.y;
            Vector3 direction = (goalPos - weaponOrigin).normalized;

            Debug.Log($"Fire with fire rate: {weaponPreference.FireRate}");

            var bullet = Instantiate(weaponPreference.BulletPrefab);
            bullet.transform.position = weaponOrigin + direction;
            bullet.Setup(Random.Range(weaponPreference.DamageMin, weaponPreference.DamageMax));

            bullet.GetComponent<Rigidbody>().AddForce(direction * 1000);

            yield return new WaitForSeconds(weaponPreference.FireRate);
            makeFireCorutine = null;
        }
    }
}

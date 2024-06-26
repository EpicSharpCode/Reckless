using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Unit.AI
{
    public class RL_NPC_AttackAbility : RL_NPC_Ability
    {
        [SerializeField] RL_WeaponPreference _weaponPreference;
        [SerializeField] float _weaponYOffset = 1;

        RL_NPC thisNPC;

        Coroutine makeFireCorutine = null;

        void Awake()
        {
            thisNPC = GetComponent<RL_NPC>();
        }

        public override void Attack() => MakeFireUpdate();
        public override void AttackAndPursuit() => MakeFireUpdate();


        void MakeFireUpdate()
        {
            if (makeFireCorutine != null) { return; }
            makeFireCorutine = StartCoroutine(MakeFire());
        }


        public IEnumerator MakeFire()
        {
            if (_weaponPreference == null) { yield break; }

            Vector3 weaponOrigin = new Vector3(
                transform.position.x,
                transform.position.y + _weaponYOffset,
                transform.position.z);
            var goal = thisNPC.Goal;
            if(goal == null) yield break;
            var goalPos = thisNPC.Goal.transform.position;
            goalPos.y = weaponOrigin.y;
            Vector3 direction = (goalPos - weaponOrigin).normalized;

            var bullet = Instantiate(_weaponPreference.BulletPrefab);
            bullet.transform.position = weaponOrigin + direction;
            bullet.Setup(Random.Range(_weaponPreference.DamageMin, _weaponPreference.DamageMax));

            bullet.GetComponent<Rigidbody>().AddForce(direction * _weaponPreference.BulletPower);

            yield return new WaitForSeconds(_weaponPreference.FireRate);
            makeFireCorutine = null;
        }
    }
}

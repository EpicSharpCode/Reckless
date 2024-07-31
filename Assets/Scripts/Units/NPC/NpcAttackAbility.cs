using Reckless.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units.AI
{
    public class NpcAttackAbility : NpcAbility
    {
        [SerializeField] WeaponPreference _weaponPreference;
        [SerializeField] float _weaponYOffset = 1;

        Npc _thisNpc;

        Coroutine _makeFireCorutine = null;

        void Awake()
        {
            _thisNpc = GetComponent<Npc>();
        }



        void MakeFireUpdate()
        {
            if (_makeFireCorutine != null) { return; }
            _makeFireCorutine = StartCoroutine(MakeFire());
        }


        public IEnumerator MakeFire()
        {
            if (_weaponPreference == null) { yield break; }

            Vector3 weaponOrigin = new Vector3(
                transform.position.x,
                transform.position.y + _weaponYOffset,
                transform.position.z);
            var goal = _thisNpc.goal;
            if(goal == null) yield break;
            var goalPos = _thisNpc.goal.transform.position;
            goalPos.y = weaponOrigin.y;
            Vector3 direction = (goalPos - weaponOrigin).normalized;

            var bullet = Instantiate(_weaponPreference.bulletPrefab);
            bullet.transform.position = weaponOrigin + direction;
            bullet.Setup(Random.Range(_weaponPreference.damageMin, _weaponPreference.damageMax));

            bullet.GetComponent<Rigidbody>().AddForce(direction * _weaponPreference.bulletPower);

            yield return new WaitForSeconds(_weaponPreference.fireRate);
            _makeFireCorutine = null;
        }
        
        
        #region Ability state methods

        public override void AttackState() => MakeFireUpdate();
        public override void AttackAndPursuitState() => MakeFireUpdate();
        public override void IdleState() {}
        public override void PatrollingState() {}
        public override void PursuitState() {}
        public override void DefenceState() {}
        
        #endregion
    }
}

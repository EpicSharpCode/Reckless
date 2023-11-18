using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    public class RL_Bullet : MonoBehaviour
    {
        public float damage;

        public void Setup(float _damage) => damage = _damage;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Collided with {collision.gameObject.name} and damage it with: {damage} points");
            var unit = collision.gameObject.GetComponent<RL_Unit>();
            if (unit != null) 
            {
                unit.Damage(damage);
            }
            Destroy(gameObject);
        }
    }
}

using System;
using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Entities
{
    public class RL_Bullet : MonoBehaviour
    {
        [SerializeField] float damage;
        
        Vector3 previousPos;

        public void Setup(float _damage) 
        {
            damage = _damage;
            StartCoroutine(DestroyBullet(5));
        }

        void FixedUpdate()
        {
            if(previousPos == Vector3.zero) { previousPos = transform.position; return; }
            
            Ray ray = new Ray(previousPos, (transform.position - previousPos));
            Debug.DrawRay(previousPos, (transform.position - previousPos), Color.green, 1);
            var raycastHits = Physics.RaycastAll(ray, Vector3.Distance(previousPos, transform.position));
            foreach (var hit in raycastHits)
            {
                TryDamage(hit.transform.gameObject);
            }
            previousPos = transform.position;
        }

        private void TryDamage(GameObject hit)
        {
            if(damage == 0) return;
            if(hit.gameObject.GetComponent<RL_Bullet>() != null) return;
            
            Debug.Log($"Collided with {hit.gameObject.name}");
            var unit = hit.gameObject.GetComponent<RL_Unit>();
            unit?.Damage(damage);
            damage = 0;
            
            StartCoroutine(DestroyBullet(0f));
        }

        IEnumerator DestroyBullet(float _sec)
        {
            yield return new WaitForSeconds(_sec);
            Destroy(gameObject);
        }
    }
}

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
                TryDamage(hit);
            }
            previousPos = transform.position;
        }

        private void TryDamage(RaycastHit hit)
        {
            if(damage == 0) return;
            if(hit.collider.GetComponent<RL_Bullet>() != null) return;
            
            var unit = hit.collider.GetComponent<RL_Unit>();
            unit?.Damage(damage);
            if (RL_Game_Variables.HitBoxPopupState)
            {
                var hitPopup = Instantiate(RL_Game_Variables.GamePrefabDatabase.HitPopupPrefab) as RL_HitPopup;
                hitPopup.transform.position = hit.point;
                hitPopup.Setup(damage);
            }
            damage = 0;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = hit.point;
            
            StartCoroutine(DestroyBullet(0.2f));
        }

        IEnumerator DestroyBullet(float _sec)
        {
            yield return new WaitForSeconds(_sec);
            Destroy(gameObject);
        }
    }
}

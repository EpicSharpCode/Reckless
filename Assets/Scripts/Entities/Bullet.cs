using System;
using Reckless.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Entities
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float _damage;
        
        Vector3 _previousPos;

        public void Setup(float damage) 
        {
            _damage = damage;
            StartCoroutine(DestroyBullet(5));
        }

        void FixedUpdate()
        {
            if(_previousPos == Vector3.zero) { _previousPos = transform.position; return; }
            
            Ray ray = new Ray(_previousPos, (transform.position - _previousPos));
            Debug.DrawRay(_previousPos, (transform.position - _previousPos), Color.green, 1);
            var raycastHits = Physics.RaycastAll(ray, Vector3.Distance(_previousPos, transform.position));
            foreach (var hit in raycastHits)
            {
                TryDamage(hit);
            }
            _previousPos = transform.position;
        }

        private void TryDamage(RaycastHit hit)
        {
            if(_damage == 0) return;
            if(hit.collider.GetComponent<Bullet>() != null) return;
            
            var unit = hit.collider.GetComponent<Unit>();
            unit?.Damage(_damage);
            if (GameVariables.hitBoxPopupState)
            {
                var hitPopup = Instantiate(GameVariables.gamePrefabDatabase.hitPopupPrefab) as HitPopup;
                hitPopup.transform.position = hit.point;
                hitPopup.Setup(_damage);
            }
            _damage = 0;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = hit.point;
            
            StartCoroutine(DestroyBullet(0.2f));
        }

        IEnumerator DestroyBullet(float sec)
        {
            yield return new WaitForSeconds(sec);
            Destroy(gameObject);
        }
    }
}

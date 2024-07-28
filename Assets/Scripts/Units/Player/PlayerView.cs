using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] bool _rotateBody = true;
        [SerializeField] Transform _body;
        [SerializeField] float _lookAtSpeed = 10;
        void Update()
        {
            if(_rotateBody) LookAtMouse();
        }

        void LookAtMouse()
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit mouseRaycastHit);
            var lookPos = mouseRaycastHit.point - _body.position; lookPos.y = 0;
            var rotateGoal = Quaternion.LookRotation(lookPos);
            _body.rotation = Quaternion.Slerp(_body.rotation, rotateGoal, Time.deltaTime * _lookAtSpeed);
        }
    }
}
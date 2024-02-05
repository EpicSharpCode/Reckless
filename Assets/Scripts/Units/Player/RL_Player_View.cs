using System;
using UnityEngine;

namespace Reckless.Unit
{
    public class RL_Player_View : MonoBehaviour
    {
        [SerializeField] Transform body;
        [SerializeField] float lookAtSpeed = 10;
        void Update()
        {
            LookAtMouse();
        }

        void LookAtMouse()
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit mouseRaycastHit);
            var lookPos = mouseRaycastHit.point - body.position; lookPos.y = 0;
            var rotateGoal = Quaternion.LookRotation(lookPos);
            body.rotation = Quaternion.Slerp(body.rotation, rotateGoal, Time.deltaTime * lookAtSpeed);
        }
    }
}
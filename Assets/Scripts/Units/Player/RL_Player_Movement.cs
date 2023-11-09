using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Unit 
{
    public class RL_Player_Movement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float speed = 10;
        [SerializeField] float gravity = 9.8f;

        CharacterController characterController;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (characterController.isGrounded)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical"); // -1 -> 1

                Vector3 moveDirection = (-transform.forward * vertical) + (-transform.right * horizontal);
                Vector3 finalMove = moveDirection * speed;

                characterController.Move(finalMove * Time.deltaTime);
            }

            Vector3 gravityMove = -transform.up * gravity;
            characterController.Move(gravityMove * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units 
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float _speed = 10;
        [SerializeField] float _gravity = 9.8f;

        CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_characterController.isGrounded)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical"); // -1 -> 1

                Vector3 moveDirection = (-transform.forward * vertical) + (-transform.right * horizontal);
                Vector3 finalMove = moveDirection * _speed;

                _characterController.Move(finalMove * Time.deltaTime);
            }

            Vector3 gravityMove = -transform.up * _gravity;
            _characterController.Move(gravityMove * Time.deltaTime);
        }
    }
}

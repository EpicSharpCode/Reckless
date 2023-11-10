using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless
{
    public class RL_Camera : MonoBehaviour
    {
        [SerializeField] RL_Player player;
        [SerializeField] float speed = 1;

        Vector3 offset;

        private void Awake()
        {
            offset = transform.position - player.transform.position;
        }

        private void Update()
        {
            if(player == null) return;
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * speed);
        }
    }
}

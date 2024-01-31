using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Reckless.Entities
{
    public class RL_HitPopup : MonoBehaviour
    {
        TMP_Text text;
        [SerializeField] AnimationCurve opacityCurve;
        [SerializeField] AnimationCurve sizeCurve;

        float time = 0;
        [SerializeField] Vector3 originalScale;

        void Awake()
        {
            text = GetComponentInChildren<TMP_Text>();
            text.transform.eulerAngles = Camera.main.transform.eulerAngles;
            originalScale = text.transform.localScale;
        }

        void FixedUpdate()
        {
            time += Time.deltaTime;
            transform.position += Vector3.up * Time.deltaTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, opacityCurve.Evaluate(time));
            text.transform.localScale = originalScale * sizeCurve.Evaluate(time);
            if (text.color.a <= 0) Destroy(gameObject);
        }
        public void Setup(float _damage)
        {
            text.text = Math.Round(_damage,1).ToString();
        }
    }
}

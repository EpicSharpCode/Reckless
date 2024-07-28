using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Entities
{
    public class HitPopup : MonoBehaviour
    {
        TMP_Text _text;
        [SerializeField] AnimationCurve _opacityCurve;
        [SerializeField] AnimationCurve _sizeCurve;

        float _time = 0;
        [SerializeField] Vector3 _originalScale;

        void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            _text.transform.eulerAngles = Camera.main.transform.eulerAngles;
            _originalScale = _text.transform.localScale;
        }

        void FixedUpdate()
        {
            _time += Time.deltaTime;
            transform.position += Vector3.up * Time.deltaTime;
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _opacityCurve.Evaluate(_time));
            _text.transform.localScale = _originalScale * _sizeCurve.Evaluate(_time);
            if (_text.color.a <= 0) Destroy(gameObject);
        }
        public void Setup(float damage)
        {
            _text.text = Math.Round(damage,1).ToString();
        }
    }
}

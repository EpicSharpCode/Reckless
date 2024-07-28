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
        public const int MAX_HIT_POPUPS = 5;
        static List<HitPopup> _hitPopups = new List<HitPopup>();
        
        TMP_Text _text;
        [SerializeField] AnimationCurve _opacityCurve;
        [SerializeField] AnimationCurve _sizeCurve;

        float _time = 0;
        Vector3 _originalScale;

        void Awake()
        {
            _hitPopups.Add(this);
            if(_hitPopups.Count > 5) { _hitPopups.RemoveAt(0); Destroy(_hitPopups[0].gameObject); }
            
            _text = GetComponentInChildren<TMP_Text>();
            _originalScale = _text.transform.localScale;
            _text.transform.localScale = Vector3.zero;
            _text.transform.eulerAngles = Camera.main.transform.eulerAngles;
        }

        void FixedUpdate()
        {
            _time += Time.deltaTime;
            transform.position += Vector3.up * Time.deltaTime;
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _opacityCurve.Evaluate(_time));
            _text.transform.localScale = _originalScale * _sizeCurve.Evaluate(_time);
            
            if (_text.color.a <= 0)
            {
                _hitPopups.Remove(this);
                Destroy(gameObject); 
            }
        }
        public void Setup(float damage)
        {
            _text.text = Math.Round(damage,1).ToString();
        }
    }
}

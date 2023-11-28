using System;
using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reckless.UI
{
    public class RL_UI_ParameterSlider : MonoBehaviour
    {
        Slider slider;
        [SerializeField] RL_Unit unit;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            UpdateParameter();
        }

        public void Init(RL_Unit _unit) => unit = _unit;

        public void UpdateParameter()
        {
            var parameter = unit?.Health;
            slider.value = parameter.Value / parameter.MaxValue;
        }
    }
}

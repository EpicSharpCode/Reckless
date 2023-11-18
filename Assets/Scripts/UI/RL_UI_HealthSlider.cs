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
        RL_Unit unit;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public void Init(RL_Unit _unit) => unit = _unit;

        public void UpdateParameter()
        {
            var parameter = unit.GetHealth();
            slider.value = parameter.GetValue() / parameter.GetMax();
        }
    }
}

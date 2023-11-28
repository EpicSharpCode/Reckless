using System;
using Reckless.Unit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reckless.UI
{
    public class RL_UI_ParameterSlider : RL_UI_ParameterOutput
    {
        Slider slider;
        RL_Unit_Parameter parameter;

        [SerializeField] string parameterName;
        [SerializeField] RL_Unit unit;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Update()
        {
            if(parameter == null) Init(unit.Parameters.Find(x=>x.ParameterName == parameterName));
            Output();
        }

        public void Init(RL_Unit_Parameter _parameter) => parameter = _parameter;
        public override void Output()
        {
            slider.value = parameter.Value / parameter.MaxValue;
        }
    }
}

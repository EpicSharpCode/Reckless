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
        RL_Unit_Parameter parameter;

        [SerializeField] string parameterName;
        [SerializeField] RL_Unit unit;

        [SerializeField] Image fillImage;
        [SerializeField] GameObject parameterContainer;

        private void Update()
        {
            if(parameter == null) Init(unit.Parameters.Find(x=>x.ParameterName == parameterName));
            parameterContainer.SetActive(parameter.Value > 0);
            Output();
        }

        public void Init(RL_Unit_Parameter _parameter) => parameter = _parameter;
        public override void Output()
        {
            fillImage.fillAmount = parameter.Value / parameter.MaxValue;
        }
    }
}

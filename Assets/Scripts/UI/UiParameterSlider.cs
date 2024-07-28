using System;
using Reckless.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Reckless.UI
{
    public class UiParameterSlider : UiParameterOutput
    {
        UnitParameter _parameter;

        [SerializeField] string _parameterName;
        [SerializeField] Unit _unit;
        [SerializeField] Image _fillImage;
        [SerializeField] GameObject _parameterContainer;

        private void Update()
        {
            if(_parameter == null) Init(_unit.parameters.Find(x=>x.parameterName == _parameterName));
            _parameterContainer.SetActive(_parameter.value > 0);
            Output();
        }

        public void Init(UnitParameter parameter) => this._parameter = parameter;
        public override void Output()
        {
            _fillImage.fillAmount = _parameter.value / _parameter.maxValue;
        }
    }
}

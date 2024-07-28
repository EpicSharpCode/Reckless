using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reckless.UI
{
    public class UiView : MonoBehaviour
    {
        CanvasGroup _canvasGroup;

        public void Awake() 
        {
            _canvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
        }

        public void Show()
        {
            transform.position = new Vector3(Screen.width / 2, Screen.height / 2, transform.position.z);
            SetPageState(true);
        }

        public void Hide() => SetPageState(false);


        void SetPageState(bool state)
        {
            if(_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
            _canvasGroup.alpha = state ? 1 : 0;
            _canvasGroup.interactable = state;
            _canvasGroup.blocksRaycasts = state;
        }
    }
    
}


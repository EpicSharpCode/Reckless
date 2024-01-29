using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reckless.UI
{
    public class RL_UI_View : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        public void Awake() 
        {
            canvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
        }

        public void Show()
        {
            transform.position = new Vector3(Screen.width / 2, Screen.height / 2, transform.position.z);
            SetPageState(true);
        }

        public void Hide() => SetPageState(false);


        void SetPageState(bool state)
        {
            if(canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
            canvasGroup.alpha = state ? 1 : 0;
            canvasGroup.interactable = state;
            canvasGroup.blocksRaycasts = state;
        }
    }
    
}


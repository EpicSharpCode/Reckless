using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.UI
{
    public class RL_UI_Controller : MonoBehaviour
    {
        [SerializeField] RL_UI_Screen currentScreen;
        [SerializeField] string defaultScreenName;
        [SerializeField] List<RL_UI_Screen> screens;

        private void Awake()
        {
            HideAllScreens();
            ShowScreen(defaultScreenName);
        }

        public void ShowScreen(string screenName)
        {
            HideCurrentScreen();
            var screen = screens.Find(_screen => _screen.GetScreenName() == screenName);
            screen.gameObject.SetActive(true);
            screen.transform.localPosition = Vector3.zero;
            currentScreen = screen;
        }

        public void HideCurrentScreen()
        {
            if(currentScreen == null) return;
            currentScreen.gameObject.SetActive(false);
        }

        public void HideAllScreens()
        {
            foreach (var scr in screens)
            {
                scr.gameObject.SetActive(false);
            }
        }
    }
}

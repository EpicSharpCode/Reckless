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
            var screen = screens.Find(_screen => _screen.ScreenName == screenName);
            screen.gameObject.SetActive(true);
            screen.transform.localPosition = Vector3.zero;
            currentScreen = screen;
        }

        public void HideCurrentScreen() => currentScreen?.gameObject.SetActive(false);

        public void HideAllScreens() => screens.ForEach(x => x.gameObject.SetActive(false));
    }
}

using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.UI
{
    [System.Serializable]
    public class RL_UI_ViewHandler
    {
        [SerializeField] string viewName;
        [SerializeField] RL_UI_View view;
        [SerializeField] bool showByDefault;

        public string ViewName => viewName;
        public RL_UI_View View => view;
        public bool ShowByDefault => showByDefault;
    }
}
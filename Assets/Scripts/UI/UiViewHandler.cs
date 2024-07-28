using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.UI
{
    [System.Serializable]
    public class UiViewHandler
    {
        [SerializeField] string _viewName;
        [SerializeField] UiView _view;
        [SerializeField] bool _showByDefault;

        public string viewName => _viewName;
        public UiView view => _view;
        public bool showByDefault => _showByDefault;
    }
}
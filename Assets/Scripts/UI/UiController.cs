using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] List<UiViewHandler> _views;
        
        void Awake() => AwakeViews();

        public void ShowView(string viewName) => ShowView(_views.Find(x => x.viewName == viewName));
        public void ShowView(UiViewHandler viewHandler) => _views.ForEach(x => { if(x == viewHandler) x?.view.Show(); else x?.view.Hide();});
        public void AwakeViews() => ShowView(_views.Find(x => x.showByDefault));
        public void HideAllViews() => _views.ForEach(x => x.view?.Hide());
    }
}

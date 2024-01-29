using System.Collections.Generic;
using UnityEngine;

namespace Reckless.UI
{
    public class RL_UI_Controller : MonoBehaviour
    {
        [SerializeField] List<RL_UI_ViewHandler> views;
        
        void Awake() => AwakeViews();

        public void ShowView(string _viewName) => ShowView(views.Find(x => x.ViewName == _viewName));
        public void ShowView(RL_UI_ViewHandler _viewHandler) => views.ForEach(x => { if(x == _viewHandler) x?.View.Show(); else x?.View.Hide();});
        public void AwakeViews() => ShowView(views.Find(x => x.ShowByDefault));
        public void HideAllViews() => views.ForEach(x => x.View?.Hide());
    }
}

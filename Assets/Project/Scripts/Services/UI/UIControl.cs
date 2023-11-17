using Grace.DependencyInjection;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public class UIControl
    {
        private readonly View _view;
        
        public UIControl(string viewName, GameObject parent, IExportLocatorScope exportLocatorScope)
        {
            _view = Object.Instantiate(Resources.Load<View>($"UI/{viewName}"), parent.transform);
            _view.name = viewName;
            exportLocatorScope.Inject(_view);
        }

        public void Close()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}
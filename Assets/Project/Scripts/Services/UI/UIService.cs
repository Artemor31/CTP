using Grace.DependencyInjection;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public sealed class UIService : IUIService
    {
        private readonly IExportLocatorScope _container;
        private readonly GameObject _canvas;
        private UIControl _viewControl;
        
        public UIService(IExportLocatorScope container)
        {
            _container = container;
            _canvas = Object.Instantiate(Resources.Load<GameObject>("UI/Canvas"));
            _canvas.name = "Canvas";
        }

        void IUIService.Show(string viewName)
        {
            _viewControl?.Close();
            _viewControl = new UIControl(viewName, _canvas, _container);
        }

        void IUIService.Close(string viewName)
        {
            _viewControl?.Close();
        }

        public TView CreateView<TView>(Transform parent) where TView : View
        {
            string name = typeof(TView).Name;
            GameObject original = Resources.Load<GameObject>($"UI/{name}");
            GameObject instance = Object.Instantiate(original, parent);
            return instance.GetComponent<TView>();
        }
    }
}
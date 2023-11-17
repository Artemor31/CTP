using System.Collections.Generic;
using Grace.DependencyInjection;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public sealed class UIService : IUIService
    {
        private readonly IExportLocatorScope _container;
        private readonly IAssetService _assetService;
        
        private readonly GameObject _canvas;
        private readonly Dictionary<string, UIControl> _viewControls;

        public UIService(IExportLocatorScope container, IAssetService assetService)
        {
            _container = container;
            _assetService = assetService;
            _viewControls = new Dictionary<string, UIControl>();
            
            _canvas = Object.Instantiate(_assetService.Load<GameObject>("UI/Canvas"));
            _canvas.name = "Canvas";
        }

        void IUIService.Show(string viewName)
        {
            UIControl control = new(viewName, _canvas, _container);
            _viewControls.Add(viewName, control);
        }

        void IUIService.Close(string viewName)
        {
            if (_viewControls.ContainsKey(viewName) == false) return;

            _viewControls[viewName].Close();
            _viewControls.Remove(viewName);
        }
    }
}
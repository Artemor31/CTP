using Grace.DependencyInjection;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.UI
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly IExportLocatorScope _exportLocatorScope;
        private readonly IAssetService _assetService;

        public UIFactory(IExportLocatorScope exportLocatorScope, IAssetService assetService)
        {
            _exportLocatorScope = exportLocatorScope;
            _assetService = assetService;
        }

        public TView CreateView<TView>(Transform parent) where TView : View
        {
            string name = typeof(TView).Name;
            
            GameObject original = _assetService.Load<GameObject>($"UI/{name}");
            GameObject instance = Object.Instantiate(original, parent);
            TView view = instance.GetComponent<TView>();
            
            _exportLocatorScope.Inject(view);
            return view;
        }
    }
}
using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUIService
    {
        void Show(string viewName);
        void Close(string viewName);
        TView CreateView<TView>(Transform parent) where TView : View;
    }
}
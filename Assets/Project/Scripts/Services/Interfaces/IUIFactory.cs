using RedPanda.Project.UI;
using UnityEngine;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUIFactory
    {
        TView CreateView<TView>(Transform parent) where TView : View;
    }
}
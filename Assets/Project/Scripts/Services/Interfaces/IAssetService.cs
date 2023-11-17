using UnityEngine;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IAssetService
    {
        T Load<T>(string path) where T : Object;
    }
}
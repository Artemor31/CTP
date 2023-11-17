using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Services
{
    public class AssetService : IAssetService
    {
        public T Load<T>(string path) where T : Object => 
            Resources.Load<T>(path);
    }
}
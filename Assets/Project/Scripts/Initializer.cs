using Grace.DependencyInjection;
using RedPanda.Project.Services;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Services.UI;
using UnityEngine;

namespace RedPanda.Project
{
    public sealed class Initializer : MonoBehaviour
    {
        private readonly DependencyInjectionContainer _container = new();
        
        private void Awake()
        {
            _container.Configure(block =>
            {
                block.Export<UserService>().As<IUserService>().Lifestyle.Singleton();
                block.Export<AssetService>().As<IAssetService>().Lifestyle.Singleton();
                block.Export<PromoService>().As<IPromoService>().Lifestyle.Singleton();
                block.Export<UIService>().As<IUIService>().Lifestyle.Singleton();
                block.Export<UIFactory>().As<IUIFactory>().Lifestyle.Singleton();

              //  block.ImportMembers<IUIService>(MembersThat.HaveAttribute<ImportAttribute>());
              });

            _container.Locate<IUserService>();
            _container.Locate<IPromoService>();
            _container.Locate<IUIFactory>();
            _container.Locate<IUIService>().Show("LobbyView");
        }
    }
}
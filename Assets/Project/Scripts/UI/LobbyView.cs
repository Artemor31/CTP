using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button _openPromo;

        private void Awake() => 
            _openPromo.onClick.AddListener(OnOpenPromoClicked);

        private void OnOpenPromoClicked() => 
            UIService.Show("PromoView");
    }
}
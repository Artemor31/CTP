using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public class PromoItem : View
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _back;
        
        private IAssetService _assetService;
        private PromoViewConfig _promoViewConfig;

        protected override void Init()
        {
            _assetService = Container.Locate<IAssetService>();
            _promoViewConfig = _assetService.Load<PromoViewConfig>(AssetPath.PromoViewConfig);
        }

        public void Setup(IPromoModel model)
        {
            _title.text = model.Title;
            _cost.text = $"x{model.Cost}";

            _icon.sprite = _promoViewConfig.GetIconFor(model.Rarity, model.Type);
            _back.sprite = _promoViewConfig.GetBackFor(model.Rarity, model.Type);
        }
    }
}
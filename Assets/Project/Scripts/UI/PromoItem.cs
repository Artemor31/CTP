using System;
using DG.Tweening;
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
        public event Action<PromoItem> Clicked;
        public int Cost { get; private set; } 
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _cost;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _back;
        [SerializeField] private Button _button;
        
        private IAssetService _assetService;
        private PromoItemsConfig _promoViewConfig;

        protected override void Init()
        {
            _assetService = Container.Locate<IAssetService>();
            _promoViewConfig = _assetService.Load<PromoItemsConfig>(AssetPath.PromoItemsConfig);
            _button.onClick.AddListener(() =>
            {
                Clicked?.Invoke(this);
                transform.DOPunchScale(Vector3.one * 0.1f, 0.2f);
            });
        }

        public void Setup(IPromoModel model)
        {
            _title.text = model.Title;
            _cost.text = $"x{model.Cost}";
            Cost = model.Cost;

            _icon.sprite = _promoViewConfig.GetIconFor(model.Rarity, model.Type);
            _back.sprite = _promoViewConfig.GetBackFor(model.Rarity, model.Type);
        }
    }
}
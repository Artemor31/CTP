using System.Collections.Generic;
using System.Linq;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoRoll : View
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private TMP_Text _header;
        
        private IEnumerable<IPromoModel> _models;
        private List<PromoItem> _items;
        private IUIFactory _factory;
        private IUserService _userService;

        protected override void Init()
        {
            _factory = Container.Locate<IUIFactory>();
            _userService = Container.Locate<IUserService>();
        }

        public void Setup(IEnumerable<IPromoModel> promoModels, string headerText)
        {
            _models = promoModels.OrderByDescending(m => m.Rarity);
            _header.text = headerText;
            _items = new List<PromoItem>();
            
            CreatePromoItems();
            SubscribeOnItems();
        }

        private void SubscribeOnItems()
        {
            foreach (PromoItem item in _items)
            {
                item.Clicked += OnItemClicked;
            }
        }

        private void OnItemClicked(PromoItem item)
        {
            if (_userService.HasCurrency(item.Cost))
            {
                _userService.ReduceCurrency(item.Cost);
                Debug.LogError($"Bought {item.Title}");
            }
            else
            {
                Debug.LogError("NOt enought credits");
            }
        }

        private void CreatePromoItems()
        {
            foreach (IPromoModel model in _models)
            {
                PromoItem item = _factory.CreateView<PromoItem>(_parent);
                item.Setup(model);
                _items.Add(item);
            }
        }
    }
}
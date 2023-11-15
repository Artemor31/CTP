using System.Collections.Generic;
using RedPanda.Project.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoRoll : View
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private TMP_Text _header;
        private IEnumerable<IPromoModel> _concretePromos;

        protected override void Init()
        {
            foreach (IPromoModel model in _concretePromos)
            {
                PromoItem item = UIService.CreateView<PromoItem>(_parent);
                item.Setup(model);
            }
        }

        public void Setup(IEnumerable<IPromoModel> concretePromos)
        {
            _concretePromos = concretePromos;
        }
    }
}
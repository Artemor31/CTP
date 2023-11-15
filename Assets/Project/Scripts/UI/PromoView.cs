using System;
using System.Collections.Generic;
using System.Linq;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public sealed class PromoView : View
    {
        [SerializeField] private Transform _rollsParent;
        
        private IPromoService _promoService;
        private List<PromoRoll> _rolls = new();

        protected override void Init()
        {
            _promoService = Container.Locate<IPromoService>();
            IReadOnlyList<IPromoModel> models = _promoService.GetPromos();
            IEnumerable<PromoType> types = Enum.GetValues(typeof(PromoType)).Cast<PromoType>();

            CreatePromoRolls(types, models);
        }
        
        private void CreatePromoRolls(IEnumerable<PromoType> types, IReadOnlyList<IPromoModel> models)
        {
            foreach (var type in types)
            {
                IEnumerable<IPromoModel> concretePromos = models.Where(m => m.Type == type);
                PromoRoll roll = UIService.CreateView<PromoRoll>(_rollsParent);
                roll.Setup(concretePromos);
                _rolls.Add(roll);
            }
        }
    }
}
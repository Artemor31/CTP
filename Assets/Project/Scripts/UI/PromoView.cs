using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<PromoRoll> _rolls;
        private IUIFactory _factory;

        protected override void Init()
        {
            _promoService = Container.Locate<IPromoService>();
            _factory = Container.Locate<IUIFactory>();
            _rolls = new List<PromoRoll>();
            
            IReadOnlyList<IPromoModel> models = _promoService.GetPromos();
            IEnumerable<PromoType> types = Enum.GetValues(typeof(PromoType)).Cast<PromoType>();

            CreatePromoRolls(types, models);
        }
        
        private void CreatePromoRolls(IEnumerable<PromoType> types, IReadOnlyList<IPromoModel> models)
        {
            foreach (PromoType type in types)
            {
                PromoRoll roll = CreatePromoRoll(models, type);
                _rolls.Add(roll);
            }
        }

        private PromoRoll CreatePromoRoll(IReadOnlyList<IPromoModel> models, PromoType type)
        {
            IEnumerable<IPromoModel> concretePromos = models.Where(m => m.Type == type);
            PromoRoll roll = _factory.CreateView<PromoRoll>(_rollsParent);
            roll.Setup(concretePromos, type.ToString());
            return roll;
        }
    }
}
using RedPanda.Project.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class PromoItem : View
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _cost;
        
        public void Setup(IPromoModel model)
        {
            _title.text = model.Title;
            _cost.text = $"x{model.Cost}";
        }
    }
}
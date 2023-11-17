using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedPanda.Project.Data
{
    [CreateAssetMenu(menuName = "Create PromoViewConfig", fileName = "PromoViewConfig", order = 0)]
    public class PromoViewConfig : ScriptableObject
    {
        [SerializeField] private List<PromoViewData> _rarityDatas;

        public Sprite GetIconFor(PromoRarity rarity, PromoType type) => 
            _rarityDatas.FirstOrDefault(r => r.Rarity == rarity && r.Type == type)?.Icon;
        
        public Sprite GetBackFor(PromoRarity rarity, PromoType type) => 
            _rarityDatas.FirstOrDefault(r => r.Rarity == rarity && r.Type == type)?.Back;
        
        [Serializable]
        private class PromoViewData
        {
            public PromoRarity Rarity;
            public PromoType Type;
            public Sprite Icon;
            public Sprite Back;
        }
    }
}
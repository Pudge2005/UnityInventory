using DevourDev.ItemsSystem.Items;
using UnityEngine;

namespace DevourDev.ItemsSystem.Examples
{
    [CreateAssetMenu(menuName = "DevourDev/Items System/Item")]
    public class ItemSo : ScriptableObject, IItem
    {
        [SerializeField] private Sprite _icon;


        public Sprite Icon => _icon;


        public virtual IItemData<ItemSo> CreateItemData()
        {
            return new ItemData(this);
        }
    }
}

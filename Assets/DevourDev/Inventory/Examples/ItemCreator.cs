using DevourDev.ItemsSystem.Items;
using UnityEngine;

namespace DevourDev.ItemsSystem.Examples
{
    [System.Serializable]
    public class ItemCreator
    {
        [SerializeField] private ItemSo _item;
        [SerializeField] private int _amount;


        public IItemAmount<ItemSo, ItemData> Create()
        {
            return new ReadOnlyItemAmount<ItemSo, ItemData>((ItemData)_item.CreateItemData(), _amount);
        }
    }
}

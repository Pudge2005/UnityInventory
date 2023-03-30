using DevourDev.ItemsSystem.Inventory;
using DevourDev.ItemsSystem.Items;

namespace DevourDev.ItemsSystem.Examples
{
    public class ItemData : IItemData<ItemSo>
    {
        private readonly ItemSo _reference;


        public ItemData(ItemSo item)
        {
            _reference = item;
        }


        public ItemSo Reference => _reference;
    }
}

using DevourDev.ItemsSystem.Inventory;

namespace DevourDev.ItemsSystem.Examples
{
    public class InventorySlot : InventorySlotBase<ItemSo, ItemData>
    {
        public InventorySlot(int slotID) : base(slotID)
        {
        }
    }
}

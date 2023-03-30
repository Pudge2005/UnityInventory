using DevourDev.ItemsSystem.Items;

namespace DevourDev.ItemsSystem.Inventory
{
    public class InventorySlotBase<TItem, TData> : IInventorySlot<TItem, TData>
        where TItem : IItem
        where TData : IItemData<TItem>
    {
        private readonly int _id;
        private TData _itemData;
        private int _amount;


        public InventorySlotBase(int slotID)
        {
            _id = slotID;
        }


        public int SlotID => _id;
        public TData Item => _itemData;
        public int Amount => _amount;

        public bool Empty => _itemData == null;


        public event System.Action<IInventorySlot<TItem, TData>,
            ReadOnlyItemAmount<TItem, TData>,
            ReadOnlyItemAmount<TItem, TData>> OnChanged;


        public void Set(TData itemData, int amount)
        {
            var tmp = new ReadOnlyItemAmount<TItem, TData>(this);
            _itemData = itemData;
            _amount = amount;
            var cur = new ReadOnlyItemAmount<TItem, TData>(this);
            OnChanged?.Invoke(this, tmp, cur);
        }
    }
}

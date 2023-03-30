using DevourDev.ItemsSystem.Items;

namespace DevourDev.ItemsSystem.Inventory
{
    public interface IInventorySlot<TItem, TData> : IItemAmount<TItem, TData>
        where TItem : IItem
        where TData : IItemData<TItem>
    {
        int SlotID { get; }
        bool Empty { get; }


        event System.Action<IInventorySlot<TItem, TData>, 
            ReadOnlyItemAmount<TItem, TData>,
            ReadOnlyItemAmount<TItem, TData>> OnChanged;
    }
}

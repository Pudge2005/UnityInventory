using System;
using System.Collections.Generic;
using DevourDev.ItemsSystem.Items;

namespace DevourDev.ItemsSystem.Inventory
{
    public delegate bool ItemReferencePredicate<TItem>(IItem itemReference)
        where TItem : IItem;

    public delegate bool ItemDataPredicate<TItem, TData>(TData itemData)
        where TItem : IItem
        where TData : IItemData<TItem>;

    public delegate bool SlotPredicate<TItem, TData, TSlot>(TSlot slot)
        where TItem : IItem
        where TData : IItemData<TItem>
        where TSlot : IInventorySlot<TItem, TData>;


    public interface IInventory<TItem, TData, TSlot> : IEnumerable<TSlot>
        where TItem : IItem
        where TData : IItemData<TItem>
        where TSlot : IInventorySlot<TItem, TData>
    {



        int Capacity { get; }

        event Action<IInventory<TItem, TData, TSlot>, IItemAmount<TItem, TData>> OnItemsAdded;
        event Action<IInventory<TItem, TData, TSlot>, IItemAmount<TItem, TData>> OnItemsRemoved;

        int Add(IItemAmount<TItem, TData> itemAmount);
        int Add(TData item, int amount);
        bool TryAdd(IItemAmount<TItem, TData> itemAmount, out int canAddAmount);

        int Remove(IItemAmount<TItem, TData> itemAmount);
        int Remove(TData item, int amount);
        bool TryRemove(IItemAmount<TItem, TData> itemAmount, out int canRemoveAmount);

        ReadOnlyMemory<TSlot> FindAll(SlotPredicate<TItem, TData, TSlot> slotPredicate);
        ReadOnlyMemory<TSlot> FindAllSlotsWithItemData(TData itemData);

        bool TryFind(ItemReferencePredicate<TItem> itemReferencePredicate, out TSlot slot);
        bool TryFind(ItemDataPredicate<TItem, TData> itemDataPredicate, out TSlot slot);
        bool TryFind(SlotPredicate<TItem, TData, TSlot> slotPredicate, out TSlot slot);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using DevourDev.ItemsSystem.Inventory;
using DevourDev.ItemsSystem.Items;
using UnityEngine;

namespace DevourDev.ItemsSystem.Examples
{
    public sealed class InventoryComponent : MonoBehaviour, IInventory<ItemSo, ItemData, InventorySlot>
    {
        [SerializeField] private int _inventorySize = 16;
        private Inventory _internalInventory;


        public int Capacity => _internalInventory.Capacity;

        public InventorySlot this[int slotIndex] => _internalInventory[slotIndex]; 


        public void SwapSlots(int indexA, int indexB)
        {
            var slotA = _internalInventory[indexA];
            var slotB = _internalInventory[indexB];

            var tmp = new ReadOnlyItemAmount<ItemSo, ItemData>(slotA);

            slotA.Set(slotB.Item, slotB.Amount);
            slotB.Set(tmp.Item, tmp.Amount);
        }


        #region IInventory
        public event Action<IInventory<ItemSo, ItemData, InventorySlot>, IItemAmount<ItemSo, ItemData>> OnItemsAdded
        {
            add
            {
                _internalInventory.OnItemsAdded += value;
            }

            remove
            {
                _internalInventory.OnItemsAdded -= value;
            }
        }

        public event Action<IInventory<ItemSo, ItemData, InventorySlot>, IItemAmount<ItemSo, ItemData>> OnItemsRemoved
        {
            add
            {
                _internalInventory.OnItemsRemoved += value;
            }

            remove
            {
                _internalInventory.OnItemsRemoved -= value;
            }
        }

        public int Add(IItemAmount<ItemSo, ItemData> itemAmount)
        {
            return _internalInventory.Add(itemAmount);
        }

        public int Add(ItemData item, int amount)
        {
            return _internalInventory.Add(item, amount);
        }

        public bool TryAdd(IItemAmount<ItemSo, ItemData> itemAmount, out int canAddAmount)
        {
            return _internalInventory.TryAdd(itemAmount, out canAddAmount);
        }

        public int Remove(IItemAmount<ItemSo, ItemData> itemAmount)
        {
            return _internalInventory.Remove(itemAmount);
        }

        public int Remove(ItemData item, int amount)
        {
            return _internalInventory.Remove(item, amount);
        }

        public bool TryRemove(IItemAmount<ItemSo, ItemData> itemAmount, out int canRemoveAmount)
        {
            return _internalInventory.TryRemove(itemAmount, out canRemoveAmount);
        }

        public ReadOnlyMemory<InventorySlot> FindAll(SlotPredicate<ItemSo, ItemData, InventorySlot> slotPredicate)
        {
            return _internalInventory.FindAll(slotPredicate);
        }

        public ReadOnlyMemory<InventorySlot> FindAllSlotsWithItemData(ItemData itemData)
        {
            return _internalInventory.FindAllSlotsWithItemData(itemData);
        }

        public bool TryFind(ItemReferencePredicate<ItemSo> itemReferencePredicate, out InventorySlot slot)
        {
            return _internalInventory.TryFind(itemReferencePredicate, out slot);
        }

        public bool TryFind(ItemDataPredicate<ItemSo, ItemData> itemDataPredicate, out InventorySlot slot)
        {
            return _internalInventory.TryFind(itemDataPredicate, out slot);
        }

        public bool TryFind(SlotPredicate<ItemSo, ItemData, InventorySlot> slotPredicate, out InventorySlot slot)
        {
            return _internalInventory.TryFind(slotPredicate, out slot);
        }

        public IEnumerator<InventorySlot> GetEnumerator()
        {
            return _internalInventory.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_internalInventory).GetEnumerator();
        }
        #endregion


        private void Awake()
        {
            _internalInventory = new(_inventorySize);
        }

       
    }
}

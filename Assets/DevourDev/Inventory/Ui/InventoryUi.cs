using DevourDev.ItemsSystem.Examples;
using DevourDev.ItemsSystem.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DevourDev.Inventory.Ui
{
    public class InventoryUi : MonoBehaviour
    {
        private InventorySlotUi _slotPrefab;
        private Transform _slotsParent;
        private InventoryComponent _inventory;

        private InventorySlotUi[] _slots;
        private InventorySlotUi _draggingSlot;
        private Vector2 _dragPos;


        public event System.Action<InventorySlotUi> OnSlotDragStarted;
        public event System.Action<PointerEventData> OnSlotDragged;
        public event System.Action OnSlotDropped;


        public InventorySlotUi DraggingSlot
        {
            get
            {
                if (_draggingSlot == null)
                    return null;

                return _draggingSlot;
            }
        }

        public Vector2 DragPosition => _dragPos;



        public void Init(InventorySlotUi slotPrefab,
            Transform slotsParent,
            InventoryComponent inventory)
        {
            _slotPrefab = slotPrefab;
            _slotsParent = slotsParent;
            _inventory = inventory;
        }

        private void Start()
        {
            BuildSlots();
        }

        private void BuildSlots()
        {
            if (_slots == null || _slots.Length < _inventory.Capacity)
                _slots = new InventorySlotUi[_inventory.Capacity];

            int i = -1;
            foreach (var sysSlot in _inventory)
            {
                var uiSlot = Instantiate(_slotPrefab, _slotsParent);
                uiSlot.InitSlot(this, ++i, sysSlot);
                _slots[i] = uiSlot;
            }
        }

        private void DestroySlots()
        {
            foreach (var uiSlot in _slots)
            {
                Destroy(uiSlot.gameObject);
            }

            var arr = _slots;
            var c = arr.Length;

            for (int i = 0; i < c; i++)
            {
                arr[i] = null;
            }
        }


        internal void ReportDragStart(InventorySlotUi slot)
        {
            if (_draggingSlot != null)
                return;

            _draggingSlot = slot;
            OnSlotDragStarted?.Invoke(slot);
        }

        internal void ReportDrag(InventorySlotUi _, PointerEventData eventData)
        {
            if (_draggingSlot == null)
                return;

            OnSlotDragged?.Invoke(eventData);
        }

        internal void ReportDragEnd(InventorySlotUi _)
        {
            if (_draggingSlot == null)
                return;

            _draggingSlot = null;
            OnSlotDropped?.Invoke();
        }

        internal void ReportDrop(InventorySlotUi slot)
        {
            if (_draggingSlot == null)
                return;

            _inventory.SwapSlots(_draggingSlot.ID, slot.ID);
            _draggingSlot = null;
            OnSlotDropped?.Invoke();
        }


    }
}

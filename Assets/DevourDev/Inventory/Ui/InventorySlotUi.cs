using DevourDev.ItemsSystem.Examples;
using DevourDev.ItemsSystem.Inventory;
using DevourDev.ItemsSystem.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DevourDev.Inventory.Ui
{
    public class InventorySlotUi : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        [SerializeField] private Image _iconImg;
        [SerializeField] private TMP_Text _amountText;

        private InventoryUi _parent;
        private int _id;
        private bool _cleared;
        private IInventorySlot<ItemSo, ItemData> _slot;


        public int ID => _id;
        public IInventorySlot<ItemSo, ItemData> Slot => _slot;


        private void OnEnable()
        {
            if (_slot != null)
                SubscribeAndActualize();
        }

        private void OnDisable()
        {
            if (_slot != null)
                _slot.OnChanged -= HandleSlotChanged;
        }

        internal void InitSlot(InventoryUi parent, int id, IInventorySlot<ItemSo, ItemData> slot)
        {
            _parent = parent;
            _id = id;
            _slot = slot;

            SubscribeAndActualize();
        }

        private void SubscribeAndActualize()
        {
            HandleSlotChanged(_slot, default, new(_slot));
            _slot.OnChanged += HandleSlotChanged;
        }

        private void HandleSlotChanged(IInventorySlot<ItemSo, ItemData> slot,
            ReadOnlyItemAmount<ItemSo, ItemData> prev,
            ReadOnlyItemAmount<ItemSo, ItemData> cur)
        {
            if (slot.Empty)
            {
                Clear();
                return;
            }

            EnsureNotCleared();
            var reference = cur.Item.Reference;
            _iconImg.sprite = reference.Icon;
            _amountText.text = GetAmountText(slot);
        }

        private void Clear()
        {
            if (_cleared)
                return;

            _cleared = true;
            _iconImg.gameObject.SetActive(false);
            _amountText.gameObject.SetActive(false);
        }

        private void EnsureNotCleared()
        {
            if (!_cleared)
                return;

            _cleared = false;
            _iconImg.gameObject.SetActive(true);
            _amountText.gameObject.SetActive(true);
        }

        private string GetAmountText(IInventorySlot<ItemSo, ItemData> slot)
        {
            if (slot.Item.Reference is not IStackableItem)
                return string.Empty;

            return slot.Amount.ToString();
        }


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (_slot.Empty)
                return;

            //выполнить действие по-умолчанию для предмета в этом слоте
            //например: экипировку - надеть; зелье - выпить; корован - ограбить

            //возможно делегирование родительскому инвентарю (_parent) с
            //контекстом в виде индекса слота (_id) и инпутом пользователя
            //(клик, долгое нажатие, перетаскивание)
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _parent.ReportDragStart(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _parent.ReportDragEnd(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            _parent.ReportDrop(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _parent.ReportDrag(this, eventData);
        }
    }
}

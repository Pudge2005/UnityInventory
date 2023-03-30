using System;
using DevourDev.ItemsSystem.Examples;
using DevourDev.ItemsSystem.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DevourDev.Inventory.Ui
{
    public sealed class DraggingItemVisualFeature : MonoBehaviour
    {
        [SerializeField] private DraggingItemUi _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private InventoryUi _ui;

        private DraggingItemUi _dragging;
        private RectTransform _rectTr;


        private void Start()
        {
            _rectTr = _parent as RectTransform;
            _ui.OnSlotDragStarted += HandleDragStarted;
            _ui.OnSlotDragged += HandleDragged;
            _ui.OnSlotDropped += HandleDropped;
        }

        private void HandleDragged(PointerEventData eventData)
        {
            if (_dragging == null)
                return;

            SyncDraggingItemPosition(eventData);
        }

        private void SyncDraggingItemPosition(PointerEventData eventData)
        {
            if (_rectTr != null)
                SyncOnCanvasPosition(eventData);
            else
                SyncWorldPosition(eventData);
        }

        private void SyncOnCanvasPosition(PointerEventData eventData)
        {
            _ = RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTr, eventData.position, null, out var localPos);
            ((RectTransform)_dragging.transform).anchoredPosition = localPos;
        }

        private void SyncWorldPosition(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }

       
        private void HandleDragStarted(InventorySlotUi uiSlot)
        {
            _dragging = Instantiate(_prefab, _parent);
            _dragging.Init(uiSlot);
        }

        private void HandleDropped()
        {
            if (_dragging == null)
                return;

            Destroy(_dragging.gameObject);
            _dragging = null;
        }

        
    }
}

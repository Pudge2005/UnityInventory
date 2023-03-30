using DevourDev.ItemsSystem.Examples;
using DevourDev.ItemsSystem.Inventory;
using UnityEngine;

namespace DevourDev.Inventory.Ui
{
    public sealed class InventoryUiInitializer : MonoBehaviour
    {
        [SerializeField] private InventoryUi _ui;

        [SerializeField] private InventorySlotUi _slotPrefab;
        [SerializeField] private Transform _slotsParent;
        [SerializeField] private InventoryComponent _inventory;


        private void Awake()
        {
            _ui.Init(_slotPrefab, _slotsParent, _inventory);
        }

    }
}

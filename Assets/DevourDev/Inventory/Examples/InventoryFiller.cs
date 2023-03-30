using UnityEngine;

namespace DevourDev.ItemsSystem.Examples
{
    public sealed class InventoryFiller : MonoBehaviour
    {
        [SerializeField] private InventoryComponent _inventory;
        [SerializeField] private ItemCreator[] _itemCreators;


        private void Start()
        {
            foreach (var creator in _itemCreators)
            {
                _inventory.Add(creator.Create());
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace DevourDev.Inventory.Ui
{
    public class DraggingItemUi : MonoBehaviour
    {
        [SerializeField] private Image _img;


        public void Init(InventorySlotUi slot)
        {
            _img.sprite = slot.Slot.Item.Reference.Icon;
            var rectTr = (RectTransform)transform;
            rectTr.sizeDelta = slot.GetComponent<RectTransform>().sizeDelta;
        }
    }
}

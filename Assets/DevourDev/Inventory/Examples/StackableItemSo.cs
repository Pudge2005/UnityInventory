using DevourDev.ItemsSystem.Items;
using UnityEngine;

namespace DevourDev.ItemsSystem.Examples
{
    [CreateAssetMenu(menuName = "DevourDev/Items System/Stackable Item")]

    public class StackableItemSo : ItemSo, IStackableItem
    {
        [SerializeField, Min(2)] private int _stackSize;


        public int StackSize => _stackSize;
    }
}

namespace DevourDev.ItemsSystem.Items
{
    public interface IItemAmount<TItem, TData>
        where TItem : IItem
        where TData : IItemData<TItem>
    {
        TData Item { get; }
        int Amount { get; }
    }
}

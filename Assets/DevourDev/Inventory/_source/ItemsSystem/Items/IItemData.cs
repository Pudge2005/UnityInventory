namespace DevourDev.ItemsSystem.Items
{
    public interface IItemData<T>
        where T : IItem
    {
        T Reference { get; }
    }
}

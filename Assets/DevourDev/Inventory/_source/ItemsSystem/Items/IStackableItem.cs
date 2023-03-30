namespace DevourDev.ItemsSystem.Items
{
    public interface IStackableItem : IItem
    {
        int StackSize { get; }
    }
}

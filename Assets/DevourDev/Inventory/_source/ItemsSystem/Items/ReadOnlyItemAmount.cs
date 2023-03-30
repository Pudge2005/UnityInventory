namespace DevourDev.ItemsSystem.Items
{
    public readonly struct ReadOnlyItemAmount<TItem, TData> : IItemAmount<TItem, TData>
        where TItem : IItem
        where TData : IItemData<TItem>
    {
        private readonly TData _item;
        private readonly int _amount;


        public ReadOnlyItemAmount(TData item, int amount)
        {
            _item = item;
            _amount = amount;
        }      

        public ReadOnlyItemAmount(IItemAmount<TItem, TData> itemAmount)
        {
            _item = itemAmount.Item;
            _amount = itemAmount.Amount;
        }


        public TData Item => _item;
        public int Amount => _amount;
    }
}

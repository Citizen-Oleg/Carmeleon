namespace Inventory
{
    public class ItemInSlot
    {
        public Item Item { get; set; }
        public int Amount { get; set; }

        public ItemInSlot(Item item, int amount = 1)
        {
            Item = item;
            Amount = amount;
        }
    }
}

namespace Interface
{
    public interface IFactory
    {
        public IProduct GetProduct(IProduct product);
        public void ReleaseProduct(IProduct product);
    }
}
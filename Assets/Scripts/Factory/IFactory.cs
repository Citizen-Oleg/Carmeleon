using System;

namespace Factory
{
    public interface IFactory<TTypeProduct> where TTypeProduct : Enum
    {
        public TProduct GetProduct<TProduct>(TTypeProduct typeProduct) where TProduct : Product;
    }
}
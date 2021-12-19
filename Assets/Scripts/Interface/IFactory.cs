using System;
using Factory;

namespace Interface
{
    public interface IFactory<TTypeProduct> where TTypeProduct : Enum
    {
        public TProduct GetProduct<TProduct>(TTypeProduct typeProduct) where TProduct : IProduct<TTypeProduct>;
    }
}
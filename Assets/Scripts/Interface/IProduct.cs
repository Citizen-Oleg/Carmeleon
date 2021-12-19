using UnityEngine;

namespace Interface
{
    public interface IProduct
    {
        public SpriteRenderer SpriteRenderer { get; }
        public int ID { get; }

    }
}
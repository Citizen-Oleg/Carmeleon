using System;
using UnityEngine;

namespace Factory
{
    public abstract class Product : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }

        public abstract Enum Type { get; }

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
    }
}
using System;
using UnityEngine;

namespace Factory
{
    public interface IProduct<TTypeEnum> where TTypeEnum : Enum
    {
        public SpriteRenderer SpriteRenderer { get; set; }
        public TTypeEnum TypeEnum { get; }
    }
}
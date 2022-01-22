using System;
using UnityEngine;

namespace ScriptsLevels.Providers
{
    [Serializable]
    public class SpriteData
    {
        public SpriteType SpriteType => _spriteType;
        public Sprite Sprite => _sprite;

        [SerializeField]
        private SpriteType _spriteType;
        [SerializeField]
        private Sprite _sprite;
    }
}

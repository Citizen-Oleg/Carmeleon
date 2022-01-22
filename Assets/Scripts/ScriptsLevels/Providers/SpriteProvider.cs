using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptsLevels.Providers
{
    public class SpriteProvider : MonoBehaviour
    {
        [SerializeField]
        private List<SpriteData> _spriteDatas = new List<SpriteData>();

        public Sprite GetSpriteByType(SpriteType spriteType)
        {
            return _spriteDatas.FirstOrDefault(spriteData => spriteData.SpriteType == spriteType)?.Sprite;
        }
    }
}

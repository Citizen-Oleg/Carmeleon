using System;
using JetBrains.Annotations;
using UnityEngine;

namespace ScriptsMenu.Settings
{
    [Serializable]
    public class ScreenData
    {
        public int Width => _width;
        public int Height => _height;

        [SerializeField]
        private int _width;
        [SerializeField]
        private int _height;
    }
}
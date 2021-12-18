using System;
using UnityEngine;

namespace NodeMovement
{
    /// <summary>
    /// Класс для расставления на карте точек, по которым будут двигаться враги.
    /// </summary>
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private Node _nextNode;

        public Node GetNextNode()
        {
            return _nextNode;
        }
    }
}

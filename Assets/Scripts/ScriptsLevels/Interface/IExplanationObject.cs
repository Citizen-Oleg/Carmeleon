
using UnityEngine;

namespace Interface
{
    public interface IExplanationObject
    {
        string Explanation { get; }
        Transform Position { get; }
    }
}
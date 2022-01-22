using TMPro;
using UnityEngine;

namespace Loot
{
    public class ReagentAnimationController
    {
        private static readonly int IsDisappearance = Animator.StringToHash("IsDisappearance");
        
        private Animator _animator;
        
        public ReagentAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void DefaultState()
        {
            _animator.SetBool(IsDisappearance, false);
        }

        public void Disappearance()
        {
            _animator.SetBool(IsDisappearance, true);
        }
    }
}
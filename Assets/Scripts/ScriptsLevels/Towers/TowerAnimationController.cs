using ScriptsLevels.Inventory;
using UnityEngine;

namespace Towers
{
    public class TowerAnimationController
    {
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        private readonly Animator _animator;
        
        public TowerAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
            _animator.SetTrigger(IsAttack);
        }

        public void ResetAttack()
        {
            _animator.ResetTrigger(IsAttack);
        }

        public bool IsActiveAnimationAttack()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        }
    }
}
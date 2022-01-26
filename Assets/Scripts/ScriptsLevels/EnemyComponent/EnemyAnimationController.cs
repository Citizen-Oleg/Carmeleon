using UnityEngine;

namespace EnemyComponent
{
    public class EnemyAnimationController
    {
        private static readonly int IsStan = Animator.StringToHash("IsStan");
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        
        private readonly Animator _animator;
        
        public EnemyAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void DefaultState()
        {
            _animator.Rebind();
        }

        public void SetAnimationDead()
        {
            _animator.SetBool(IsDead, true);
        }

        public void SetAnimationStan(bool isStan)
        {
            _animator.SetBool(IsStan, isStan);
        }
    }
}
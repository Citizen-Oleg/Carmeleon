using UnityEngine;

namespace EnemyComponent
{
    public class EnemyAnimationController
    {
        private static readonly int IsStan = Animator.StringToHash("IsStan");
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsCast = Animator.StringToHash("IsCast");
        
        private readonly Animator _animator;
        
        public EnemyAnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void DefaultState()
        {
            _animator.Rebind();
        }

        public void SetMoving(bool isMoving)
        {
            _animator.SetBool(IsMoving, isMoving);
        }

        public void SetAnimationDead()
        {
            _animator.SetBool(IsDead, true);
        }

        public void SetAnimationStan(bool isStan)
        {
            _animator.SetBool(IsStan, isStan);
        }

        public void CastBuff()
        {
            _animator.SetTrigger(IsCast);
        }

        public void ResetCast()
        {
            _animator.ResetTrigger(IsCast);
        }
    }
}
using System;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Animator))]
    public class TowerAnimationController : MonoBehaviour
    {
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");
        
        [SerializeField]
        private GameObject _chains;
        [SerializeField]
        private Animator _animator;

        public void Attack()
        {
            _animator.SetTrigger(IsAttack);
        }

        public void ResetAttack()
        {
            _animator.ResetTrigger(IsAttack);
            SetDisplayChains(true);
        }

        public void Refresh()
        {
            _animator.Rebind();
        }

        public void SetDisplayChains(bool canAttack)
        {
            _chains.gameObject.SetActive(!canAttack);
        }

        public bool IsActiveAnimationAttack()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        }
    }
}
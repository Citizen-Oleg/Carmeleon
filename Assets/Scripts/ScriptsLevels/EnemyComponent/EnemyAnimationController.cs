using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyComponent
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimationController : MonoBehaviour
    {
        private static readonly int IsStan = Animator.StringToHash("IsStan");
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsCast = Animator.StringToHash("IsCast");

        [SerializeField]
        private Color _defaultColor = Color.white;
        [SerializeField]
        private Color _frostColor = Color.blue;
        [SerializeField]
        private List<SpriteRenderer> _spriteRenderers = new List<SpriteRenderer>();
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void DefaultState()
        {
            _animator.Rebind();
            SetFreezeColor(false);
        }

        public void SetMoving(bool isMoving)
        {
            _animator.SetBool(IsMoving, isMoving);
        }

        public void SetAnimationDead()
        {
            _animator.StopPlayback();

            _animator.SetBool(IsDead, true);
        }

        public void SetAnimationStan(bool isStan)
        {
            _animator.SetBool(IsStan, isStan);
        }

        public void SetAnimationFrozen(bool isFrozen)
        {
            SetFreezeColor(isFrozen);
            if (isFrozen)
            {
                _animator.StartPlayback();
            }
            else
            {
                _animator.StopPlayback();
            }
        }

        private void SetFreezeColor(bool isFrozen)
        {
            foreach (var spriteRenderer in _spriteRenderers) 
            {
                spriteRenderer.color = isFrozen ? _frostColor : _defaultColor;
            }
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
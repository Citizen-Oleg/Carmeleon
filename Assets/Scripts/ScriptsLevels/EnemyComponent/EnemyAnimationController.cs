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
        private List<SpriteRenderer> _spriteRenderers = new List<SpriteRenderer>();
        [SerializeField]
        private Color _defaultColor = Color.white;
        
        [Header("Ice settings")]
        [SerializeField]
        private Color _frostColor = Color.blue;
        [SerializeField]
        private GameObject _ice;
        
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

        public void SetAnimationDead(bool isDead)
        {
            if (isDead)
            {
                _animator.StopPlayback();
            }
            
            _animator.SetBool(IsDead, isDead);
        }

        public void SetAnimationStan(bool isStan)
        {
            _animator.SetBool(IsStan, isStan);
        }

        public void SetAnimationFrozen(bool isFrozen)
        {
            SetFreezeColor(isFrozen);
            _ice.gameObject.SetActive(isFrozen);
            
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
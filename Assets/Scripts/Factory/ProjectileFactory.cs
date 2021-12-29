using System;
using System.Collections.Generic;
using Interface;
using Towers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Factory
{
    public class ProjectileFactory : MonoBehaviour, IFactory
    {
        [SerializeField]
        private Transform _containerProjectile;
        [SerializeField]
        private Projectile _prefabStandardProjectile;
        [SerializeField]
        private SplashProjectile _splashStandardProjectile;
        [SerializeField]
        private List<Projectile> _projectiles = new List<Projectile>();
        
        private Dictionary<Projectile, MonoBehaviourPool<Projectile>> _projectilePool = new Dictionary<Projectile, MonoBehaviourPool<Projectile>>();

        private void Awake()
        {
            var pool = new MonoBehaviourPool<Projectile>(_prefabStandardProjectile, _containerProjectile, 20);
            _projectilePool.Add(_prefabStandardProjectile, pool);
            pool = new MonoBehaviourPool<Projectile>(_splashStandardProjectile, _containerProjectile, 20);
            _projectilePool.Add(_splashStandardProjectile, pool);
           
           _projectiles = BubbleSortProduct.GetSortList(_projectiles);
        }

        public IProduct GetProduct(IProduct product)
        {
            product = GetProjectileByID(product.ID);
            
            switch (product)
            {
                case SplashProjectile splashProjectile:
                    var projectilePool = _projectilePool[_splashStandardProjectile].Take();
                    SetProductParametersByBlueprint(splashProjectile, ref projectilePool);

                    if (projectilePool is SplashProjectile projectileSplashPool)
                    {
                        projectileSplashPool.ExplosionRadius = splashProjectile.ExplosionRadius;
                    }

                    return projectilePool;
                
                case Projectile projectile:
                    projectilePool = _projectilePool[_prefabStandardProjectile].Take();
                    SetProductParametersByBlueprint(projectile, ref projectilePool);
                    return projectilePool;
            }

            return product;
        }

        public void ReleaseProduct(IProduct product)
        {
            switch (product)
            {
                case SplashProjectile splashProjectile:
                    _projectilePool[_splashStandardProjectile].Release(splashProjectile);
                    break;
                case Projectile projectile:
                    _projectilePool[_prefabStandardProjectile].Release(projectile);
                    break;
            }
        }

        private void SetProductParametersByBlueprint(Projectile projectileBlueprint, ref Projectile productProjectile)
        {
            var spriteRendererProjectile = projectileBlueprint.SpriteRenderer;
            var spriteRendererProduct = productProjectile.SpriteRenderer;

            spriteRendererProduct.color = spriteRendererProduct.color;
            spriteRendererProduct.sprite = spriteRendererProjectile.sprite;

            productProjectile.FlightSpeed = projectileBlueprint.FlightSpeed;
        }

        private Projectile GetProjectileByID(int id)
        {
            return _projectiles[id];
        }
    }
}
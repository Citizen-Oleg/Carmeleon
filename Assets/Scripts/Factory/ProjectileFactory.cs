using System;
using System.Collections.Generic;
using Interface;
using Towers;
using UnityEngine;

namespace Factory
{
    public class ProjectileFactory : MonoBehaviour, IFactory
    {
        [SerializeField]
        private Transform _containerProjectile;
        [SerializeField]
        private Projectile _prefabProjectile;
        [SerializeField]
        private SplashProjectile _splashProjectile;
        [SerializeField]
        private List<Projectile> _projectiles = new List<Projectile>();
        
        private Dictionary<Projectile, MonoBehaviourPool<Projectile>> _projectilePool = new Dictionary<Projectile, MonoBehaviourPool<Projectile>>();

        private void Awake()
        {
            var pool = new MonoBehaviourPool<Projectile>(_prefabProjectile, _containerProjectile, 30);
            _projectilePool.Add(_prefabProjectile, pool);
            pool = new MonoBehaviourPool<Projectile>(_splashProjectile, _containerProjectile, 30);
            _projectilePool.Add(_splashProjectile, pool);

            _projectiles = BubbleSortProduct.GetSortList(_projectiles);
        }

        public IProduct GetProduct(IProduct product)
        {
            product = GetProjectileByID(product.ID);
            
            switch (product)
            {
                case SplashProjectile splashProjectile:
                    var projectilePool = _projectilePool[_splashProjectile].Take();
                    SetProductParametersByBlueprint(splashProjectile, ref projectilePool);

                    if (projectilePool is SplashProjectile projectileSplashPool)
                    {
                        projectileSplashPool.ExplosionRadius = splashProjectile.ExplosionRadius;
                    }

                    return projectilePool;
                
                case Projectile projectile:
                    projectilePool = _projectilePool[_prefabProjectile].Take();
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
                    _projectilePool[_splashProjectile].Release(splashProjectile);
                    break;
                case Projectile projectile:
                    _projectilePool[_prefabProjectile].Release(projectile);
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
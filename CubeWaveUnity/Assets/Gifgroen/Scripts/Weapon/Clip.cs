using System;
using UnityEngine;

namespace Gifgroen.Weapon
{
    [CreateAssetMenu(fileName = "New Clip", menuName = "ClipType/Clip")]
    public class Clip : ScriptableObject
    {
        [SerializeField] private Projectile projectile;

        [SerializeField] private float capacity;

        private void OnValidate()
        {
            if (projectile == null)
            {
                throw new ArgumentException( "Cannot execute without a Projectile script");
            }
        }

        public float Capacity() => capacity; 
        
        public GameObject NewProjectile(Vector3 projectileSpawnPoint)
        {
            return Instantiate(projectile.gameObject, projectileSpawnPoint, Quaternion.identity);
        }
    }
}
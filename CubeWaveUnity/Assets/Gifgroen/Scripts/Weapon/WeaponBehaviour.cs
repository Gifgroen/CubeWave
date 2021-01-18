using UnityEngine;

namespace Gifgroen.Weapon
{
    public class WeaponBehaviour : MonoBehaviour
    {
        [SerializeField] private Clip clip;

        [SerializeField] private Transform projectileSpawnPoint;

        public void Fire()
        {
            GameObject spawn = clip.NewProjectile(projectileSpawnPoint.position);
            if (spawn.TryGetComponent(out Projectile p))
            {
                p.SetMoveDirection(transform.forward);
            }
        }

        public void Reload(Clip newClip)
        {
            clip = newClip;
            Debug.Log($"Reload()");
        }
    }
}
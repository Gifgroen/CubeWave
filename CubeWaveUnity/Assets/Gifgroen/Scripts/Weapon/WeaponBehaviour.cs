using UnityEngine;

namespace Gifgroen.Weapon
{
    public class WeaponBehaviour : MonoBehaviour
    {
        [SerializeField] private Clip clip;

        [SerializeField] private Transform projectileSpawnPoint;

        [SerializeField] private WeaponConfiguration weaponConfiguration;

        private void OnEnable()
        {
            weaponConfiguration.FireEvent += OnFire;
        }

        private void OnDisable()
        {
            weaponConfiguration.FireEvent -= OnFire;
        }

        public void Reload(Clip newClip)
        {
            clip = newClip;
            Debug.Log($"Reload()");
        }

        public void OnFire()
        {
            GameObject spawn = clip.NewProjectile(projectileSpawnPoint.position);
            if (spawn.TryGetComponent(out Projectile p))
            {
                p.SetMoveDirection(transform.forward);
            }
        }
        

    }
}
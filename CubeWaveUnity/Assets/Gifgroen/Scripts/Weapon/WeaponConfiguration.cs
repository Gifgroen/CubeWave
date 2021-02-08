using UnityEngine;

namespace Gifgroen.Weapon
{
    [CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Weapon/Config", order = 0)]
    public class WeaponConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject visual;
        
        [SerializeField] private Vector3 forward = Vector3.right;

        public GameObject GetVisual()
        {
            return visual;
        }
        
        public Vector3 GetForward()
        {
            return forward;
        }
    }
}
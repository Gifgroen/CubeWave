using UnityEngine;

namespace Gifgroen.Weapon
{
    [CreateAssetMenu(fileName = "New Clip", menuName = "ClipType/Clip")]
    public class Clip : ScriptableObject
    {
        [SerializeField] private Projectile projectile;

        [SerializeField] private GameObject visual;

        [SerializeField] private float capacity;
    }
}
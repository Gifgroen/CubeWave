using System;
using UnityEngine;

namespace Gifgroen.Weapon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        [SerializeField] private Vector3 forward = Vector3.forward;

        #region Unity lifecycle
        private void Update()
        {
            transform.position += speed * Time.deltaTime * forward;
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }

        #endregion

        public void SetMoveDirection(Vector3 newForward)
        {
            forward = newForward;
        }
    }
}
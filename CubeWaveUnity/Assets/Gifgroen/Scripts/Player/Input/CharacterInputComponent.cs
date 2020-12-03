using Gifgroen.Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gifgroen.Player.Input
{
    public class CharacterInputComponent : MonoBehaviour
    {
        [SerializeField] public CharacterMovementComponent movement;

        // ReSharper disable once UnusedMember.Global
        public void Move(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            if (value == Vector2.right)
            {
                movement.SetMoveRight();
            }
            else if (value == Vector2.left)
            {
                movement.SetMoveLeft();
            }
            else if (value == Vector2.zero)
            {
                movement.SetStopMove();
            }
        }
    }
}
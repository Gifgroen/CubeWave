using Gifgroen.Utils;
using UnityEngine;

namespace Gifgroen.Player.Items
{
    public class ItemManagement : MonoBehaviour
    {
        [SerializeField] private Transform backpack;

        [SerializeField] private Transform leftHand;

        [SerializeField] private Transform rightHand;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Transform cTransform = transform;
            Vector3 position = cTransform.position;

            Gizmos.color = Color.green;
            DrawArrow.ForGizmo(position + Vector3.up * 0.5f, cTransform.forward);

            Matrix4x4 rotationMatrix = Matrix4x4.TRS(position, cTransform.rotation, cTransform.lossyScale);
            Gizmos.matrix = rotationMatrix;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(backpack.localPosition, new Vector3(.5f, .5f, .1f));

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(leftHand.localPosition, .1f);
            Gizmos.DrawWireSphere(rightHand.localPosition, .1f);
        }
#endif
    }
}
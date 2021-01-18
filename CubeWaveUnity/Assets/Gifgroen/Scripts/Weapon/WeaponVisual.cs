#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
#endif
using UnityEngine;

namespace Gifgroen.Weapon
{
    [ExecuteAlways]
    public class WeaponVisual : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private GameObject visual;
#endif

        [SerializeField] private Vector3 forward = Vector3.right;

        [SerializeField, HideInInspector] private GameObject currentVisual;

#if UNITY_EDITOR

        #region Unity Lifecycle

        private void OnValidate()
        {
            EditorApplication.delayCall -= UpdateVisual;
            EditorApplication.delayCall += UpdateVisual;
        }

        #endregion

        #region Visual Instantiation

        private void UpdateVisual()
        {
            if (PrefabStageUtility.GetCurrentPrefabStage() != null)
            {
                return;
            }

            if (visual == null)
            {
                // No visual to show. Deleted existing visual if present!
                if (currentVisual == null) return;
                DestroyImmediateVisual();
                return;
            }

            if (currentVisual == null)
            {
                // There is no currentVisual, but we did get a new template. Created it!
                currentVisual = InstantiateVisual(visual, transform);
                return;
            }

            if (visual.name == currentVisual.name)
            {
                // The template visual is the same as we have. Bail out, do nothing.
                FaceDirection(currentVisual, forward);
                return;
            }

            // There is an existing visual, but we got a new/different visual. Deleted old, created new!
            DestroyImmediateVisual();
            currentVisual = InstantiateVisual(visual, transform);
            FaceDirection(currentVisual, forward);
        }

        private void DestroyImmediateVisual()
        {
            DestroyImmediate(currentVisual);
            currentVisual = null;
        }

        private static GameObject InstantiateVisual(GameObject toInstantiate, Transform parent)
        {
            GameObject newVisual = Instantiate(toInstantiate, parent.position, Quaternion.identity, parent);
            newVisual.name = toInstantiate.name;
            newVisual.hideFlags = HideFlags.NotEditable;
            return newVisual;
        }

        private static void FaceDirection(GameObject go, Vector3 newForward)
        {
            go.transform.forward = newForward;
        }

        #endregion

#endif
    }
}
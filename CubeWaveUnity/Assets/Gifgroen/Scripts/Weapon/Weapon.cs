using UnityEditor;
using UnityEngine;

namespace Gifgroen.Weapon
{
    [ExecuteAlways]
    public class Weapon : MonoBehaviour
    {
        [Header("Logic")]
        [SerializeField] private Clip clip;

        [Header("Vfx")]
        [SerializeField] private GameObject visual;

        private GameObject _currentVisual;

        private void OnValidate()
        {
            EditorApplication.delayCall -= UpdateVisual;
            EditorApplication.delayCall += UpdateVisual;
        }
        
        public static void Fire()
        {
            Debug.Log("Fire()");
        }

        public void Reload(Clip newClip)
        {
            Debug.Log($"Reload()");
        }

        private void UpdateVisual()
        {
            if (visual == null)
            {
                // No visual to show. Deleted existing visual if present!
                if (_currentVisual == null) return;
                DestroyImmediateVisual();
                return;
            }

            if (_currentVisual == null)
            {
                // There is no currentVisual, but we did get a new template. Created it!
                InstantiateVisual(visual);
                return;
            }

            if (visual.name == _currentVisual.name)
            {
                // The template visual is the same as we have. Bail out, do nothing.
                return;
            }

            // There is an existing visual, but we got a new/different visual. Deleted old, created new!
            DestroyImmediateVisual();
            InstantiateVisual(visual);
        }

        private void DestroyImmediateVisual()
        {
            DestroyImmediate(_currentVisual);
            _currentVisual = null;
        }

        private void InstantiateVisual(GameObject toInstantiate)
        {
            _currentVisual = Instantiate(toInstantiate, transform);
            _currentVisual.name = toInstantiate.name;
            _currentVisual.transform.forward = Vector3.left;
            _currentVisual.hideFlags = HideFlags.NotEditable;
        }
    }
}
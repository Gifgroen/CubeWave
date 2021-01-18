using UnityEditor;
using UnityEngine;

namespace Gifgroen.Weapon.Editor
{
    [CustomEditor(typeof(WeaponBehaviour))]
    public class WeaponCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);
            
            WeaponBehaviour weaponBehaviour = (WeaponBehaviour) target;
            if (GUILayout.Button("Reload"))
            {
                weaponBehaviour.Reload(null);
            }

            if (GUILayout.Button("Fire"))
            {
                weaponBehaviour.Fire();
            }                
        }
    }
}

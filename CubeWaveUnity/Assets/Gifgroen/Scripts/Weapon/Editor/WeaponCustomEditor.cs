using UnityEditor;
using UnityEngine;

namespace Gifgroen.Weapon.Editor
{
    [CustomEditor(typeof(Weapon))]
    public class WeaponCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();


            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);
            
            Weapon weapon = (Weapon) target;
            if (GUILayout.Button("Reload"))
            {
                weapon.Reload(null);
            }

            if (GUILayout.Button("Fire"))
            {
                Weapon.Fire();
            }                
        }
    }
}

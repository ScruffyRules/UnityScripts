#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

public class CopyMaterials : EditorWindow
{
    private Object firstObject;
    private Object secondObject;
    private GameObject fromGO;
    private GameObject toGO;

    [MenuItem("Component/Custom/Copy SMR Materials")]
    static void Init()
    {
        CopyMaterials window = (CopyMaterials)EditorWindow.GetWindow(typeof(CopyMaterials));
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Copy Materials", EditorStyles.boldLabel);

        firstObject = EditorGUILayout.ObjectField("From Object", firstObject, typeof(GameObject), true);
        secondObject = EditorGUILayout.ObjectField("To Object", secondObject, typeof(GameObject), true);

        // Safe cast. Won't exception on fail.
        fromGO = firstObject as GameObject;
        toGO = secondObject as GameObject;

        if (fromGO != null & toGO != null)
        {
            var fromSMR = fromGO.GetComponent(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;
            var toSMR = toGO.GetComponent(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer;
            
            if (fromSMR == null)
            {
                firstObject = null;
                secondObject = null;

                GUILayout.Label("FromSMR is null");
                return;
            }

            if (toSMR == null) 
            {
                firstObject = null;
                secondObject = null;
                
                GUILayout.Label("ToSMR is null");
                return;
            }
                
            if (GUILayout.Button("Copy!"))
            {
                var mats = fromSMR.sharedMaterials.ToArray();

                toSMR.materials = mats;
                
                firstObject = null;
                secondObject = null;
            }
            
        }
    }
}
#endif
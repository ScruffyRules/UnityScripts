#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

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
        fromGO = (GameObject)firstObject;
        toGO = (GameObject)secondObject;

        if (fromGO != null & toGO != null)
        {
            SkinnedMeshRenderer fromSMR = (SkinnedMeshRenderer) fromGO.GetComponent(typeof(SkinnedMeshRenderer));
            SkinnedMeshRenderer toSMR = (SkinnedMeshRenderer) toGO.GetComponent(typeof(SkinnedMeshRenderer));
            
            if (fromSMR != null)
            {
                if (toSMR != null)
                {
                    if (GUILayout.Button("Copy!"))
                    {
                        Material[] mats = new Material[fromSMR.sharedMaterials.Length];
                        for (int i = 0; i < fromSMR.sharedMaterials.Length; i++)
                        {
                            mats[i] = fromSMR.sharedMaterials[i];
                        }
                        toSMR.materials = mats;
                        firstObject = null;
                        secondObject = null;
                    }
                }
                else
                {
                    GUILayout.Label("ToSMR is null");
                }
            } else
            {
                GUILayout.Label("FromSMR is null");
            }
        }
    }
}
#endif
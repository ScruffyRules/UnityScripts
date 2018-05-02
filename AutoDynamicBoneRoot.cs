#if UNITY_EDITOR
using UnityEngine;
using System.Collections;

[UnityEditor.InitializeOnLoad]
public class AutoDynamicBoneRoot
{

    static AutoDynamicBoneRoot()
    {
        UnityEditor.EditorApplication.hierarchyWindowChanged += OnHierarchyWindowChanged;
    }

    static void OnHierarchyWindowChanged()
    {
        AddRootsToDynBones();
    }

    public static void AddRootsToDynBones()
    {
        DynamicBone[] allDynamicBones = Resources.FindObjectsOfTypeAll<DynamicBone>();
        foreach (DynamicBone src in allDynamicBones)
        {
			
            if (src == null || src.gameObject == null || !src.enabled || src.gameObject.scene != UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene())
            {
                continue;
            }
			
            
			if (src.m_Root == null) {
				Debug.Log("Found DynamicBone (" + src.gameObject.name + ") without root entry");
				src.m_Root = src.gameObject.transform;
			}
        }
    }

}
#endif
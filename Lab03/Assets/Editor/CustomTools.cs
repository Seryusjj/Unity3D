
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This class has the purpose of generate the folder inside our unity proyect automatically
/// it's an Unity3D Editor script which is goint to extend the editor functionality
/// </summary>
public class CustomTools
{

    private static string applicationPath = Application.dataPath + "/";

    /// <summary>
    /// Create a new menu item at the top call Custom Tools 
    /// and a submenu inside that one call Make Folders,it also provide
    /// this submenu with functionality.
    /// </summary>
    [MenuItem("Custom Tools/Make Folders ")]
    static void CreateFolders()
    {
        MakeProjectFolders();
    }

    /// <summary>
    /// Create a new menu item at the top call Custom Tools 
    /// and a submenu inside that one call Make Prefabs,it also provide
    /// this submenu with functionality.
    /// </summary>
    [MenuItem("Custom Tools/Make Prefab ")]
    static void CreatePrefab()
    {
        MakePrefabFromSelection();

    }


    private static void MakePrefabFromSelection()
    {
        GameObject[] selected = Selection.gameObjects;

        foreach (GameObject obj in selected)
        {
            String localPath = "Assets/" + obj.name + ".prefab";
            if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
            {
                if (EditorUtility.DisplayDialog("Caution!", "Prefab already exits.Do you want to overrite?", "Yes", "No"))
                {
                    CreateNewPrefab(localPath, obj);
                }
            }
            else
            {
                CreateNewPrefab(localPath, obj);
            }

        }

    }

    private static void CreateNewPrefab(String path, GameObject selected)
    {
        Debug.Log(path);
        var newPrefab = PrefabUtility.CreateEmptyPrefab(path);
        PrefabUtility.ReplacePrefab(selected, newPrefab);
        AssetDatabase.Refresh();


        //replace he existing object with the prefab
        UnityEngine.Object.DestroyImmediate(selected);
        PrefabUtility.InstantiatePrefab(newPrefab);

    }


    /// <summary>
    /// Generate the following folders: Audio, Materials, Scritps,
    /// Meshes, Fonts, Textures, Resources, Shaders, Packages, Physics
    /// </summary>
    private static void MakeProjectFolders()
    {
        System.IO.Directory.CreateDirectory(applicationPath + "Audio");
        System.IO.Directory.CreateDirectory(applicationPath + "Materials");
        System.IO.Directory.CreateDirectory(applicationPath + "Scritps");
        System.IO.Directory.CreateDirectory(applicationPath + "Meshes");
        System.IO.Directory.CreateDirectory(applicationPath + "Fonts");
        System.IO.Directory.CreateDirectory(applicationPath + "Textures");
        System.IO.Directory.CreateDirectory(applicationPath + "Resources");
        System.IO.Directory.CreateDirectory(applicationPath + "Shaders");
        System.IO.Directory.CreateDirectory(applicationPath + "Packages");
        System.IO.Directory.CreateDirectory(applicationPath + "Physics");
        AssetDatabase.Refresh();

    }
}


using System.Collections;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This class has the purpose of generate the folder inside our unity proyect automatically
/// it's an Unity3D Editor script which is goint to extend the editor functionality
/// </summary>
public class FolderCreator {

    /// <summary>
    /// Create a new menu item at the top call Custom Tools 
    /// and a submenu inside that one call Make Folders,it also provide
    /// this submenu with functionality
    /// </summary>
    [MenuItem("Custom Tools/Make Folders")]
    static void DoSomething()
    {
        MakeProject();
    }

    static void MakeProject()
    {
        Debug.Log("Doing Something...");
    }
}

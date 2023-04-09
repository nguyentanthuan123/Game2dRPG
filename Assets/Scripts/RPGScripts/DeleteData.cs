using UnityEditor;
using UnityEngine;
using System.IO;

[ExecuteInEditMode]
public class DeleteData : MonoBehaviour
{
    public static void DeletePathData()
    {
        string path = Application.persistentDataPath + "/player.data";
        File.Delete(path);
    }
}

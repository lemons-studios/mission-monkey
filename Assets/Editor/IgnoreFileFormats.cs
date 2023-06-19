using UnityEngine;
using UnityEditor;
public class IgnoreFileFormats : MonoBehaviour
{
    [MenuItem("Assets/Ignore File Types")]
    private static void IgnoreFileTypes()
    {
        // Add any file format that needs to be ignored later in this array
        string[] ignoredFileExtensions = { ".blend1" };

        SerializedObject editorSettings = new SerializedObject(AssetDatabase.LoadAllAssetRepresentationsAtPath("ProjectSettings/EditorSettings.asset")[0]);
        SerializedProperty serializedProperty = editorSettings.FindProperty("m_DefaultBehaviorMode");

        serializedProperty.ClearArray();
        serializedProperty.arraySize = ignoredFileExtensions.Length;
        for (int i = 0; i < ignoredFileExtensions.Length; i++)
        {
            SerializedProperty extensionProperty = serializedProperty.GetArrayElementAtIndex(i);
            extensionProperty.stringValue = ignoredFileExtensions[i];
        }

        editorSettings.ApplyModifiedPropertiesWithoutUndo();

        Debug.Log("Ignored File formats list Updated!");
    }
}

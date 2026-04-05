using UnityEngine;
using UnityEditor;

public class EditorWindowExample : EditorWindow
{
    [MenuItem("Window/ExampleEditorWindow")]
    public static void ShowWindow()
    {
        EditorWindowExample window = GetWindow<EditorWindowExample>();
    }

    string exampleString = "";
    void OnGUI()
    {
        Debug.Log("Im Displaying!!!");

        exampleString = GUILayout.TextField(exampleString);
    }
}

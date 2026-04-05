using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExampleScript))]
public class EditorExtensionExample : Editor
{
    SerializedProperty scoreVariable;
    void OnEnable()
    {
        scoreVariable = serializedObject.FindProperty("score");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        scoreVariable.intValue = EditorGUILayout.IntField(scoreVariable.intValue);

        if(GUILayout.Button("Reset Score"))
        {
            scoreVariable.intValue = 0;
        }

        serializedObject.ApplyModifiedProperties();
    }
}

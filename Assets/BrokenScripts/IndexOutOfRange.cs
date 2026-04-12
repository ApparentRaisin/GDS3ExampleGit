using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using JetBrains.Annotations;

public class IndexOutOfRange : MonoBehaviour
{
    InputAction movement;

    public TextMeshPro textMeshDisplay;
    String[] textLinesToDisplay = new string[4] {"I am an NPC", "this is me talking", "I'm really hopeful", "I wont out of range"};
    void Start()
    {
        movement = InputSystem.actions.FindAction("Move");
    }

    int listPosition = 0;

    void Update()
    {
        Vector2 dir = movement.ReadValue<Vector2>();
        
        listPosition += Mathf.RoundToInt(dir.y);

        textMeshDisplay.text = textLinesToDisplay[listPosition];
    }
}

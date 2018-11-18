using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Clickable), true)]
[CanEditMultipleObjects]
public class ClickableEditor : Editor
{
    // Current click event
    private SerializedProperty clickEvent;

    public override void OnInspectorGUI()
    {
        // Get reference to the clickable object being inspected
        Clickable obj = (Clickable)target;

        // Draw debug fields
        obj.id = EditorGUILayout.TextField("ID:", obj.id);

        // Draw the click response event
        clickEvent = serializedObject.FindProperty("clickResponse");
        EditorGUILayout.PropertyField(clickEvent);

        // Toggle
        obj.isToggle = EditorGUILayout.Toggle("Toggle", obj.isToggle);

        // Display toggle events
        if(obj.isToggle)
        {
            // Draw the toggle on response event
            clickEvent = serializedObject.FindProperty("toggleOnResponse");
            EditorGUILayout.PropertyField(clickEvent);

            // Draw the toggle off response event
            clickEvent = serializedObject.FindProperty("toggleOffResponse");
            EditorGUILayout.PropertyField(clickEvent);
        }

        // Apply all property modifications
        serializedObject.ApplyModifiedProperties();
    }

    public void OnSceneGUI()
    {
        // Get reference to clickable object
        Clickable obj = (Clickable)target;
        if (obj.id == "") return;

        Vector3 objScreenPos = Camera.current.WorldToScreenPoint(obj.transform.position);
        Vector2 size = new Vector2(100.0f, 20.0f);
        Vector2 finalPos = new Vector2(objScreenPos.x - size.x / 2, Camera.current.pixelHeight - objScreenPos.y - size.y / 2);

        // Begin Drawing GUI
        Handles.BeginGUI();

        GUI.Box(new Rect(finalPos, size), obj.id);

        // End GUI Drawing
        Handles.EndGUI();
    }
}
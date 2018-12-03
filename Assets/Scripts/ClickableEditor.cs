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

        // Draw the click response event
        clickEvent = serializedObject.FindProperty("clickResponse");
        EditorGUILayout.PropertyField(clickEvent);

        // Toggles
        GUILayout.BeginHorizontal();
        obj.useToggle = EditorGUILayout.Toggle("Toggle", obj.useToggle);
        obj.useHover = EditorGUILayout.Toggle("Hover", obj.useHover);
        GUILayout.EndHorizontal();

        // Display toggle events
        if(obj.useToggle)
        {
            obj.startToggleEnabled = EditorGUILayout.Toggle("Start On", obj.startToggleEnabled);

            // Draw the toggle on response event
            clickEvent = serializedObject.FindProperty("toggleOnResponse");
            EditorGUILayout.PropertyField(clickEvent);

            // Draw the toggle off response event
            clickEvent = serializedObject.FindProperty("toggleOffResponse");
            EditorGUILayout.PropertyField(clickEvent);
        }

        // Display Hover Events
        if(obj.useHover)
        {
            // Draw the hover enter response event
            clickEvent = serializedObject.FindProperty("hoverEnterResponse");
            EditorGUILayout.PropertyField(clickEvent);

            // Draw the hover exit response event
            clickEvent = serializedObject.FindProperty("hoverExitResponse");
            EditorGUILayout.PropertyField(clickEvent);
        }

        // Apply all property modifications
        serializedObject.ApplyModifiedProperties();
    }
}
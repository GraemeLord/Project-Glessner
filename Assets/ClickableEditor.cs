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
}
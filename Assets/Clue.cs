using UnityEngine;

[RequireComponent(typeof(Clickable3D))]
public class Clue : MonoBehaviour
{
    [Tooltip("Define this object's clue information.")]
    public ClueInfo clueInfo;

    [Tooltip("Clue runtime collection.")]
    public ClueCollection clueCollection;

    private void OnEnable()
    {
        clueCollection.Add(this);
    }

    private void OnDisable()
    {
        clueCollection.Remove(this);
    }
}
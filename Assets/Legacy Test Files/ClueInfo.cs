using UnityEngine;

[CreateAssetMenu(fileName = "New Clue", menuName = "Clue")]
public class ClueInfo : ScriptableObject
{
    public string displayName;
    public ClueType type;
    public Sprite image;
    public string correctDescription;
    public string incorrectDescription;
}
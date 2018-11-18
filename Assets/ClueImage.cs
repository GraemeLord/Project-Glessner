using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClueImage : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetImage(Clue clue)
    {
        image.sprite = clue.clueInfo.image;
    }
}
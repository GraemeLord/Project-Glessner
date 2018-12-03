using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClueContainer : MonoBehaviour
{
    [Tooltip("Which clue should this container display?")]
    public ClueInfo clue;

    [Tooltip("Time taken to fade the clue once revealed.")]
    public float fadeDuration = 1.0f;

    [Tooltip("Clue container runtime collection.")]
    public ClueContainerCollection clueContainerCollection;

    // Image display component
    private Image image;

    private void OnEnable()
    {
        clueContainerCollection.Add(this);
    }

    private void OnDisable()
    {
        clueContainerCollection.Remove(this);
    }

    private void Start()
    {
        // Get the image component
        image = GetComponent<Image>();

        // Check that clue information exists
        if(clue != null)
        {
            // Set image ref
            image.sprite = clue.image;
        }

        // Set start alpha to 0
        image.CrossFadeAlpha(0.0f, 0.0f, true);
    }

    public void Reveal()
    {
        // Fade the image to a target alpha of 1 with given fade duration
        image.CrossFadeAlpha(1.0f, fadeDuration, false);
    }
}
using UnityEngine;
using UnityEngine.Events;

public abstract class Clickable : MonoBehaviour
{
    public bool isToggle = false;
    private bool isOn = false;

    // Events
    public UnityEvent clickResponse;
    public UnityEvent toggleOnResponse;
    public UnityEvent toggleOffResponse;

    // Define click behaviour
    public abstract bool IsObjectClicked();

    public void Update()
    {
        // Check if the object was clicked
        if (IsObjectClicked())
        {
            // Invoke the click response (occurs every time the object is clicked)
            clickResponse.Invoke();

            // Check if the toggle functionality is enabled
            if (isToggle)
            {
                // On -> Off
                if (isOn)
                {
                    toggleOffResponse.Invoke();
                }
                // Off -> On
                else
                {
                    toggleOnResponse.Invoke();
                }

                // Flip state
                isOn = !isOn;
            }
        }
    }
}
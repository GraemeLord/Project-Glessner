using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    // Flags
    public bool useToggle = false;
    public bool useHover = false;
    public bool startToggleEnabled = false;

    protected bool isOn = false;
    protected bool isHover = false;

    // Events
    public UnityEvent clickResponse;
    public UnityEvent toggleOnResponse;
    public UnityEvent toggleOffResponse;
    public UnityEvent hoverEnterResponse;
    public UnityEvent hoverExitResponse;

    private void Start()
    {
        // Set initial on state
        if(useToggle && startToggleEnabled)
        {
            isOn = true;
            toggleOnResponse.Invoke();
        }
    }

    public bool IsOn()
    {
        return isOn;
    }

    public void Flip()
    {
        isOn = !isOn;
    }
}
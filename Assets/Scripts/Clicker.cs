using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Clickable target3D;
    private Clickable previousTarget3D;

    private void Update()
    {
        Click3D();
    }

    private void Click3D()
    {
        // Reset target state
        target3D = null;

        // Raycast from the mouse position
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Perform raycast
        if (Physics.Raycast(ray, out hit))
        {
            // If hit a clickable game object
            if (hit.transform.gameObject.GetComponent<Clickable>() != null)
            {
                // Set as target
                target3D = hit.transform.gameObject.GetComponent<Clickable>();

                // Check for left click
                if (Input.GetMouseButtonDown(0) && target3D.enabled)
                {
                    target3D.clickResponse.Invoke();

                    if(target3D.useToggle)
                    {
                        if(target3D.IsOn())
                        {
                            target3D.toggleOffResponse.Invoke();
                        }
                        else
                        {
                            target3D.toggleOnResponse.Invoke();
                        }

                        target3D.Flip();
                    }
                }
            }
        }

        // New target does not match previous target
        if (target3D != previousTarget3D)
        {
            // Trigger exit response on previous clickable
            if(previousTarget3D != null && previousTarget3D.useHover && previousTarget3D.enabled)
            {
                previousTarget3D.hoverExitResponse.Invoke();
            }

            // If the new target is a clickable
            if(target3D != null && target3D.useHover && target3D.enabled)
            {
                // Trigger enter response
                target3D.hoverEnterResponse.Invoke();
            }
        }

        // Set Previous Target
        previousTarget3D = target3D;
    }

    private void Click2D()
    {

    }
}
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Clickable3D : Clickable
{
    public override bool IsObjectClicked()
    {
        // Check for left click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform raycast
            if (Physics.Raycast(ray, out hit))
            {
                // If hit this game object
                if (hit.transform.gameObject == gameObject)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
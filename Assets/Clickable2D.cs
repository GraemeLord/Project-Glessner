using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Clickable2D : Clickable
{
    public override bool IsObjectClicked()
    {
        // Check for left click
        if(Input.GetMouseButtonDown(0))
        {
            // Check if the 2D collider bounds contains the mouse position
            if(GetComponent<Collider2D>().bounds.Contains(Input.mousePosition))
            {
                return true;
            }
        }

        return false;
    }
}
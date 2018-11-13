using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, 45.0f * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, -45.0f * Time.deltaTime, Space.World);
        }
    }
}
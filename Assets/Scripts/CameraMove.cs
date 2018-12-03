using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Keypad6))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }

        if(Input.GetKey(KeyCode.Keypad4))
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }

        if(Input.GetKey(KeyCode.Keypad8))
        {
            transform.position += new Vector3(transform.forward.x, 0.0f, transform.forward.z) * Time.deltaTime * moveSpeed;
        }

        if(Input.GetKey(KeyCode.Keypad2))
        {
            transform.position -= new Vector3(transform.forward.x, 0.0f, transform.forward.z) * Time.deltaTime * moveSpeed;
        }
    }
}
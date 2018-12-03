using UnityEngine;

/*
 * 
 */
public class CameraTilt : MonoBehaviour
{
    public float forwardMaxRotation;
    public float backwardMaxRotation;

    public float degreesPerSecond;

    private float rotation = 0.0f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rotation += Time.deltaTime * degreesPerSecond;
            if(rotation > forwardMaxRotation)
            {
                rotation = forwardMaxRotation;
            }
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            rotation -= Time.deltaTime * degreesPerSecond;
            if(rotation < -backwardMaxRotation)
            {
                rotation = -backwardMaxRotation;
            }
        }

        transform.rotation = Quaternion.Euler(30.0f + rotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}

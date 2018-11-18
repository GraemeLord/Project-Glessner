using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    [Tooltip("The cooldown of the spin (seconds)")]
    public float cooldown;

    [Tooltip("How long it takes to transition to next rotation")]
    public float spinDuration;

    private Quaternion target;
    private Quaternion start;

    private float t = 1.0f;
    private float cooldownTimer;

    private void Start()
    {
        // Set initial target as own rotation
        start = transform.rotation;
        target = start;
        cooldownTimer = cooldown;
    }

    private void Update ()
    {
        // Check for user input
        CheckForInput();

        // Stop execution if no rotation target
        if (target.eulerAngles.magnitude == 0)
            return;

        // Rotate towards target
        float currentY = Mathf.LerpAngle(transform.rotation.eulerAngles.y, target.eulerAngles.y, t);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentY, transform.rotation.eulerAngles.z);
	}

    private void CheckForInput()
    {
        // If cooldown timer has passed the necessary cooldown
        if(cooldownTimer > cooldown)
        {
            // Left Arrow
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                start = transform.rotation;
                target = Quaternion.Euler(30.0f, target.eulerAngles.y + 90.0f, 0.0f);
                t = 0.0f;
                cooldownTimer = 0.0f;
            }

            // Right Arrow
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                start = transform.rotation;
                target = Quaternion.Euler(30.0f, target.eulerAngles.y - 90.0f, 0.0f);
                t = 0.0f;
                cooldownTimer = 0.0f;
            }
        }

        // Increment timers
        t += Time.deltaTime / spinDuration;
        cooldownTimer += Time.deltaTime;
    }
}

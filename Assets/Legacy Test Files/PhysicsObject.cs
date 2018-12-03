using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        // Get the rigid body component
        rb = GetComponent<Rigidbody>();
    }

    public void AddForwardImpulse(float force)
    {
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

    public void AddUpwardImpulse(float force)
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    public void AddRightImpulse(float force)
    {
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
    }
}
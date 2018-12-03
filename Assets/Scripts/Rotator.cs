using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Clickable))]
public class Rotator : MonoBehaviour
{
    public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    public float angle = 45.0f;
    public float duration = 1.0f;
    public Vector3 axis = Vector3.up;

    public void RotateForward()
    {
        StartCoroutine(Rotation(true));
    }

    public void RotateBackward()
    {
        StartCoroutine(Rotation(false));
    }

    private IEnumerator Rotation(bool forward)
    {
        GetComponent<Clickable>().enabled = false;
        float t = 0.0f;
        int direction = forward == true ? 1 : -1;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(angle * axis.x * direction, angle * axis.y * direction, angle * axis.z * direction);

        while(t < 1.0f)
        {
            t += Time.deltaTime * (1 / duration);
            float c = curve.Evaluate(t);

            transform.rotation = Quaternion.Lerp(startRotation, endRotation, c);
            yield return null;
        }

        GetComponent<Clickable>().enabled = true;
    }
}
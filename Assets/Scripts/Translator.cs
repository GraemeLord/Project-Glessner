using UnityEngine;
using System.Collections;

public class Translator : MonoBehaviour
{
    public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    public float distance = 1.0f;
    public float duration = 1.0f;
    public Vector3 relativeTo = Vector3.forward;

    public void TranslateForward()
    {
        StartCoroutine(Translation(true));
    }

    public void TranslateBackward()
    {
        StartCoroutine(Translation(false));
    }

    private IEnumerator Translation(bool forward)
    {
        GetComponent<Clickable>().enabled = false;
        float t = 0.0f;
        int direction = forward == true ? 1 : -1;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + (relativeTo * distance * direction);

        while(t < 1.0f)
        {
            t += Time.deltaTime;
            float c = curve.Evaluate(t);

            transform.position = Vector3.Lerp(startPosition, endPosition, c);
            yield return null;
        }
        GetComponent<Clickable>().enabled = true;
    }
}
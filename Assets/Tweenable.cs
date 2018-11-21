using UnityEngine;
using System.Collections;

public class Tweenable : MonoBehaviour
{
    [Header("Animation")]
    public float enterDuration = 1;
    public float exitDuration = 1;
    public AnimationCurve inCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    public AnimationCurve outCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    [Header("Offsets")]
    public Vector3 startOffset;
    public Vector3 midOffset;
    public Vector3 endOffset;

    private Vector3 startPoint;
    private Vector3 midPoint;
    private Vector3 endPoint;


    private void Start()
    {
        // Calculate points
        startPoint = transform.position + startOffset;
        midPoint = transform.position + midOffset;
        endPoint = transform.position + endOffset;

        // Set to start
        transform.position = startPoint;
    }

    public void Enter()
    {
        StartCoroutine(Tween(startPoint, midPoint, inCurve, enterDuration));
    }

    public void Exit()
    {
        StartCoroutine(Tween(midPoint, endPoint, outCurve, exitDuration));
    }

    private IEnumerator Tween(Vector2 a, Vector2 b, AnimationCurve curve, float duration)
    {
        float t = 0.0f;
        while(t < 1.0f)
        {
            t += Time.deltaTime * (1 / duration);
            transform.position = (b - a) * curve.Evaluate(t) + a;
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3[] corners = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(corners);
        Vector2 size = new Vector2(corners[3].x - corners[0].x, corners[1].y - corners[0].y);

        // Calculate points in advance if the application is not running
        if(!Application.isPlaying)
        {
            startPoint = transform.position + startOffset;
            midPoint = transform.position + midOffset;
            endPoint = transform.position + endOffset;
        }

        // Start
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(startPoint, size);
        Gizmos.DrawWireSphere(startPoint, 10.0f);

        // Mid
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(midPoint, size);
        Gizmos.DrawWireSphere(midPoint, 10.0f);

        // End
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(endPoint, size);
        Gizmos.DrawWireSphere(endPoint, 10.0f);

        // Lines
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(startPoint, midPoint);
        Gizmos.DrawLine(midPoint, endPoint);
    }
}
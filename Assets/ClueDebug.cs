using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshPro))]
public class ClueDebug : MonoBehaviour
{
    public Vector3 size = Vector3.one;
    public Color color = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
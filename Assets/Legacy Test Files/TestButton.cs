using UnityEngine;
using UnityEngine.Events;

public class TestButton : MonoBehaviour
{
    public bool on;

    public UnityEvent OnResponse;
    public UnityEvent OffResponse;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    if(on)
                    {
                        OffResponse.Invoke();
                    }
                    else
                    {
                        OnResponse.Invoke();
                    }

                    on = !on;
                }
            }
        }
    }
}
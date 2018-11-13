using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVisibility : MonoBehaviour {

    public int id;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material = new Material(GetComponent<MeshRenderer>().material);
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

        GameObject go = new GameObject("Number", typeof(TextMesh));
        go.transform.position = transform.position + Vector3.up * 0.5f;
        go.GetComponent<TextMesh>().text = id.ToString();
        go.GetComponent<TextMesh>().fontSize = 500;
        go.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
	}
}

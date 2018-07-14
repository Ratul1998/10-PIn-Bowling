using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Ball b;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - b.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (b.transform.position.z <= 1750f)
        {
            transform.position = b.transform.position + offset;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody r;
    private Vector3 ballStartPos;
    private AudioSource a;
    public bool inPlay = false;
	// Use this for initialization
	void Start () {
        ballStartPos = transform.position;
        r = GetComponent<Rigidbody>();
        
        r.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        a = GetComponent<AudioSource>();
        r.useGravity = true;
        r.velocity = velocity;
        a.Play();
    }
    public void reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        r.velocity = Vector3.zero;
        r.angularVelocity = Vector3.zero;
        r.useGravity = false ;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public float StandingThreshold=3f;
    public float distanceToRaise = 40;
    private Rigidbody rg;
    void Start () {
        rg = GetComponent<Rigidbody>();
	}
	
	
	void Update () {
		
	}
    public bool isStanding()
    {
        Vector3 r = transform.rotation.eulerAngles;
        float tiltinX =Mathf.Abs(270-r.x);
        float tiltinZ =Mathf.Abs(r.z);
        if(tiltinX<StandingThreshold && tiltinZ< StandingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Raise()
    {
        if (isStanding())
        {
            rg.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    }
    public void Lower()
    {
        rg.useGravity = true;
        transform.Translate(new Vector3(0,-distanceToRaise, 0), Space.World);
    }
}

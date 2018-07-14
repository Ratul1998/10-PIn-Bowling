using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLaunch : MonoBehaviour {
    private Ball b;
    private Vector3 dragStart, dragend;
    private float startTime, endTime;
    private bool inPlay = false;
	// Use this for initialization
	void Start () {
        b = GetComponent<Ball>();
	}
	
	public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime =Time.time;
    }
    public void DragEnd()
    {
        dragend = Input.mousePosition;
        endTime =Time.time;
        float dragDuration = endTime - startTime;
        float launchSpeedX = (dragend.x-dragStart.x) / dragDuration;
        float launchSpeedZ = (dragend.y - dragStart.y) / dragDuration;
        Vector3 LaunchVelocity = new Vector3(2*launchSpeedX, 0, launchSpeedZ);
        b.Launch(LaunchVelocity);
        inPlay = true;
    }
    public void MoveStart(float amt)
    {
        if (!inPlay)
        {
            b.transform.Translate(new Vector3(amt, 0, 0));
        }
    }
}

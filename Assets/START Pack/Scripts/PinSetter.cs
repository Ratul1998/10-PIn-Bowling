using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public int LastStandingCount = -1;
    private float LastChangeTime;
    public Text t;
    private bool ballEnteredBox=false;
    private Ball b;
    public GameObject pinSet;
    void Start()
    {
        b = GameObject.FindObjectOfType<Ball>();
    }
	void Update () {
        t.text = CountStanding().ToString();
        if (ballEnteredBox)
        {
            CheckStanding();
        }
	}
    public int CountStanding()
    {
        int Standing =0;
        foreach(Pin p in GameObject.FindObjectsOfType<Pin>())
        {
            if (p.isStanding())
            {
                Standing++;
            }
        }
        return Standing;
    }
    void OnTriggerEnter(Collider col)
    {
        GameObject thingHit = col.gameObject;
        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            t.color = Color.red;
        }
    }
    void OnTriggerExit(Collider col)
    {
        GameObject thingleft = col.gameObject;
        if (thingleft.GetComponent<Pin>())
        {
            Destroy(thingleft);
        }
    }
    void CheckStanding()
    {
        int currentStanding = CountStanding();
        if (currentStanding != LastStandingCount)
        {
            LastChangeTime = Time.time;
            LastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if ((Time.time - LastChangeTime) > settleTime)
        {
            pinsHaveSettled();
        }
    }
    void pinsHaveSettled()
    {
        b.reset();
        LastStandingCount = -1;
        ballEnteredBox = false;
        t.color = Color.green;
    }
    public void RaisePins()
    {
        foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
        {
            p.Raise();
        }
    }
    public void lowerPins()
    {
        foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
        {
            p.Lower();
        }
    }
    public void RenewPins()
    {
       Instantiate(pinSet,new Vector3(0,19,1829),Quaternion.identity);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinSetter : MonoBehaviour
{
    
    public Text standingDisplay;
    public int lastStandingCount = -1;
    public float distanceToRaise = 0.40f;
    public GameObject pinSet;


    [SerializeField]
    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox;
    void Start()
    {
        
    }

    public void RaisePins()
    {
        Debug.Log("raisepins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
    }
    public void LowerPins()
    {
        Debug.Log("lowerpins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }
    public void RenewPins()
    {
        Debug.Log("renewpins");
        Instantiate(pinSet, new Vector3(0, 30, 1829),Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
         standingDisplay.text = CountStanding().ToString();
         //print(CountStanding());

        if(ballEnteredBox)
        {
            CheckStanding();
        }
    }

    void CheckStanding()
    {
        int currentStanding = CountStanding();

        if(currentStanding !=lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float setterTime = 3f;
        if((Time.time -lastChangeTime)>setterTime)
        {
            PinsHaveSettled();
        }
    }
    void PinsHaveSettled()
    {
        ball.Reset();
        lastChangeTime = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }
    
    int CountStanding()
    {
        int standing = 0;
        //print(standing);
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
    
    void OnTriggerExit(Collider col)
    {
        GameObject thingLeft = col.gameObject;
        if(thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        GameObject thingHit = col.gameObject;

        if(thingHit.GetComponent<Ball>())
        {
           // print("triggered");
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
        
    }
}

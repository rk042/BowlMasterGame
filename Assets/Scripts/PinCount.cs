using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinCount : MonoBehaviour
{
    public Text standingDisplay;


    private int lastStandingCount = -1; 
    
    private float lastChangeTime;
    private int lastSutterCount = 10;

    [SerializeField]
    private Ball ball;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private PinSetter pinsetter;
    [SerializeField]
    private PinSetter pinsettter;
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            pinsettter.ballEnteredBox = true;
            Debug.Log("collider enter");
        }

    }
    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        //print(CountStanding());
        //print(ballEnteredBox);
        if (pinsetter.ballEnteredBox)
        {
            CheckStanding();
            standingDisplay.color = Color.red;

        }
       
    }
    int CountStanding()
    {
        int standing = 0;
        //print(standing);
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
    void CheckStanding()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float setterTime = 3f;
        if ((Time.time - lastChangeTime) > setterTime)
        {
            PinsHaveSettled();
        }
    }
    void PinsHaveSettled()
    {
        int pinFall = lastSutterCount - CountStanding();
        lastSutterCount = CountStanding();
        //print("pinFall " + pinFall);
        //print("LastSutterCount"+lastSutterCount);
        if (pinFall < 10)
        {
            ball.Reset();
        }

        lastChangeTime = -1;
        //  ballEnteredBox = false;
        standingDisplay.color = Color.green;
        pinsetter.ballEnteredBox = false;
        if (pinFall == 10)
        {
            anim.SetTrigger("ResetTrigger");
            lastSutterCount = 10;
        }
    }
}

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

   
    private Ball ball;
    
    private Animator anim;
   
    private PinSetter pinsetter;

    private ScoreDisplay scoredisplay;
  
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        anim = GameObject.FindObjectOfType<Animator>();
        pinsetter = GameObject.FindObjectOfType<PinSetter>();
        scoredisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            pinsetter.ballEnteredBox = true;
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
            print("reset pinfall < 10"+"---"+pinFall);
            scoredisplay.getpincount(pinFall);
        }

        lastChangeTime = -1;
        //  ballEnteredBox = false;
        standingDisplay.color = Color.green;
        pinsetter.ballEnteredBox = false;
        if (pinFall == 10)
        {
            Debug.Log("reset trigger");
            anim.SetTrigger("ResetTrigger");
            ball.Reset();
            lastSutterCount = 10;
            
        }
    }

    
}

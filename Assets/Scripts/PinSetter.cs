using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinSetter : MonoBehaviour
{
    
    
  
    public float distanceToRaise = 0.40f;
    public GameObject pinSet;
    public bool ballEnteredBox;

    private Ball ball;
    void Start()
    {
        ball = gameObject.GetComponent<Ball>();
    }

    public void RaisePins()
    {
       // Debug.Log("raisepins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
            
        }
    }
    public void LowerPins()
    {
       // Debug.Log("lowerpins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
            //standingDisplay.color = Color.black;
        }
    }
    public void RenewPins()
    {
        Debug.Log("renewpins");
        Instantiate(pinSet, new Vector3(0, 30, 1829),Quaternion.identity);
        ball.Reset();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    
 
   
 
    //void OnTriggerEnter(Collider col)
    //{
    //    GameObject thingHit = col.gameObject;

    //    if(thingHit.GetComponent<Ball>())
    //    {
    //       // print("triggered");
    //        ballEnteredBox = true;
    //        standingDisplay.color = Color.red;
    //    }
        
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingTreshold=3f;
    public float distToRaise = 40f;

    private Rigidbody rigitbody;
    void Start()
    {
        // print(name + IsStanding());
        rigitbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // print(name + IsStanding());
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        //print(name+standingTreshold);
        float tiltInx = Mathf.Abs(270-rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);
        //print(name+rotationInEuler.x+"and"+name+rotationInEuler.z);
       // print(name+tiltInx + "and " +name+ tiltInZ);
        if (tiltInx < standingTreshold && tiltInZ < standingTreshold)
        {
            //print("this is if true");
            return true;
            
        }
        else
        {
           // print("this is if false");
            return false;
           
        }
        
    }
    public void Raise()
    {
        if (IsStanding())
        {
            rigitbody.useGravity = false;
            transform.Translate(new Vector3(0,distToRaise, 0),Space.World);
        }
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
            rigitbody.useGravity = true;
        }
    }
}

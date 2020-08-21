using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 lunchVelocity;

    public bool isPlay = false;

    [SerializeField]
    private Rigidbody ballRigidbody;

    [SerializeField]
    private AudioSource BallRunSound;
    void Start()
    {
        ballRigidbody.useGravity = false;
        //BallLunch(lunchVelocity);
      
    }

    public void BallLunch(Vector3 velocity)
    {
        isPlay = true;
        ballRigidbody.useGravity = true;
        BallRunSound.Play();

        ballRigidbody.velocity = velocity;
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}

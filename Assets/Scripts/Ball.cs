﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 lunchVelocity;
    public bool isPlay = false;

    [SerializeField]
    private PinSetter pinSetter;
    private Vector3 ballStartPos;
    [SerializeField]
    private Rigidbody ballRigidbody;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource BallRunSound;
   
    void Start()
    {
        ballRigidbody.useGravity = false;
       
        //BallLunch(lunchVelocity);
        ballStartPos = transform.position;
    }

    public void BallLunch(Vector3 velocity)
    {
        isPlay = true;
        ballRigidbody.useGravity = true;
        BallRunSound.Play();

        ballRigidbody.velocity = velocity;
    }

    // ball reset after one throuv
    public void Reset()
    {
        anim.SetTrigger("TidyTrigger");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("TidyTrigger");
        isPlay = false;
        transform.position = ballStartPos;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.useGravity = true;
        
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}

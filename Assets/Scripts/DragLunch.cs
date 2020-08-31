using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Ball))]
public class DragLunch : MonoBehaviour
{
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    public void DragStart()
    {
        if (!ball.isPlay)
        {
           dragStart = Input.mousePosition;
           startTime = Time.time;
        }
            
    }
    public void MoveStart(float amount)
    {
        if (!ball.isPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            //ball.transform.Translate(new Vector3(xPos, yPos, zPos));
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
        Debug.Log("amount-----" + amount);
    }
    public void DragEnd()
    {
        if (!ball.isPlay)
        {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;
        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

        ball.BallLunch(launchVelocity);
        }
        
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Ball))]
public class DragLunch : MonoBehaviour
{
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    [SerializeField]
    private Ball ball;

    void Start()
    {
        
    }

    public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }
    public void MoveStart(float amount)
    {
        if (!ball.isPlay)
        {
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }
        Debug.Log("amount-----" + amount);
    }
    public void DragEnd()
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

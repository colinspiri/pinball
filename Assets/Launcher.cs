using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private GameObject sittingBall;
    
    public KeyCode key;
    private bool holding = false;
    private float holdTimer = 0.0f;

    public float maxForce;
    public float maxHoldTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindSittingBall();
        
        Debug.Log("sitting ball = " + sittingBall);

        // hold down launch key
        if (Input.GetKey(key))
        {
            holdTimer += Time.deltaTime;
        }
        // when released, launch the ball if it's there
        else if (holding)
        {
            if (sittingBall != null)
            {
                // give ball velocity based on holdTimer
                float ratio = holdTimer / maxHoldTime;
                if (ratio > 1) ratio = 1.0f;
                float force = maxForce * ratio;
                Debug.Log("launching ball with hold ratio = " + holdTimer + " / " + maxHoldTime);
                sittingBall.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, force));
            }
            holdTimer = 0.0f;
        }
        holding = Input.GetKey(key);
        
        // scale position to hold down timer
        float holdRatio = holdTimer / maxHoldTime;
        if (holdRatio > 1) holdRatio = 1.0f;
        float zPos = -0.42f - 0.04f * holdRatio; // -0.46 is max
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zPos);
    }

    private void FindSittingBall()
    {
        float distanceToNearestBall = float.MaxValue;
        GameObject nearestBall = null;
        foreach(GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);
            if (distance < distanceToNearestBall)
            {
                distanceToNearestBall = distance;
                nearestBall = ball;
                
            }
        }

        if (distanceToNearestBall < 1.5f)
        {
            sittingBall = nearestBall;
        }
        else sittingBall = null;
    }
    
}

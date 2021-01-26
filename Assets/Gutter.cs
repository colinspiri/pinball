using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    [NonSerialized] public int ballsLost = 0;

    public BallSpawner ballSpawner;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        ballsLost++;
        Debug.Log("lost another ball " + ballsLost);
        if (ballsLost >= ballSpawner.maxBalls)
        {
            gameManager.EndGame();
        }
    }
}

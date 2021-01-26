using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [NonSerialized] public int points = 0;

    public KeyCode restartGameKey;

    public Launcher launcher;
    public BallSpawner ballSpawner;

    public Text pointsText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // restart game
        if (Input.GetKeyDown(restartGameKey))
        {
            points = 0;
            ballSpawner.ballsSpawned = 0;
            GameObject[] oldBalls = GameObject.FindGameObjectsWithTag("Ball");
            for (int i = 0; i < oldBalls.Length; i++)
            {
                Debug.Log(i + " " + oldBalls.Length);
                Destroy(oldBalls[i]);
            }
            ballSpawner.SpawnBall();
        }
        
        // update UI
        pointsText.text = "Points: " + points;
    }
    
}

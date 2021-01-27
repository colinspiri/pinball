using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    [NonSerialized] public int ballsLost = 0;

    public BallSpawner ballSpawner;
    public GameManager gameManager;

    private AudioSource loseBallSound;
    
    // Start is called before the first frame update
    void Start()
    {
        loseBallSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        ballsLost++;
        loseBallSound.Play();
        Debug.Log("lost another ball " + ballsLost);
        if (ballsLost >= ballSpawner.maxBalls)
        {
            gameManager.EndGame();
        }
    }
}

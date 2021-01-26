using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public int maxBalls;
    [NonSerialized] public int ballsSpawned = 0;

    public GameObject ballPrefab;

    public Launcher launcher;

    public Text ballsText;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();

        ballsText.text = "Balls Spawned: " + ballsSpawned + "/" + maxBalls;
    }

    // Update is called once per frame
    void Update()
    {
        ballsText.text = "Balls Spawned: " + ballsSpawned + "/" + maxBalls;
    }

    public void SpawnBall()
    {
        Debug.Log("spawn a ball");
        GameObject newBall = Instantiate(ballPrefab, new Vector3(4.3f, 0.6f, 0.0f), Quaternion.identity);
        ballsSpawned++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>().velocity.x < 0)
        {
            if (ballsSpawned < maxBalls)
            {
                SpawnBall();
            }
            else Debug.Log("Cannot spawn new ball - " + ballsSpawned + "/" + maxBalls + " balls spawned");
        }
        else Debug.Log("ball entering launcher pit!");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public GameManager game;
    public int pointsWorth;

    private AudioSource pointsSound;
    
    // Start is called before the first frame update
    void Start()
    {
        pointsSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        game.points += pointsWorth;
        pointsSound.Play();
    }
}

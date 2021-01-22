using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public KeyCode pushKey;
    private Rigidbody rb;
    public int forceDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(pushKey))
        {
            rb.AddTorque(0,  100000000000 * forceDirection, 0);
        }
    }
}

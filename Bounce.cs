﻿using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody rb;
    public float BounceForce = 500f;
    public int BounceChance = 100;
    public int BounceFrequency = 100;

    private bool Bouncy = true;

    //public float BounceHeightTrigger = 1.2f;
    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        // get the distance to ground
        distToGround = GetComponent<Collider>().bounds.extents.y;

        if (!(Random.Range(0, 100) < BounceChance))
        {
            Bouncy = false;
            //Debug.Log("No Bounce");
        }
        else
        {
            //Debug.Log("Yes Bounce");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Bouncy)
        {
            //if (rb.position.y < BounceHeightTrigger)
            if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f))
            {
                if (Random.Range(0, 100) < BounceFrequency)
                {
                    rb.AddForce(0, BounceForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                    //rb.velocity = new Vector3(rb.velocity.x, BounceForce / 100, rb.velocity.z);
                }
            }
        }
    }
}

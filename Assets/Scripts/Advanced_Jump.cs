using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advanced_Jump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowjumpMultiplier = 2.0f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowjumpMultiplier - 1) * Time.deltaTime;
        }
	}
}

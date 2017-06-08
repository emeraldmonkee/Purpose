using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hover : MonoBehaviour
{

    public float hoverHeight = 5.0f;
    public float hoverForce = 100.0f;
    public float proportionalHeight;

    public float fallMultiplier = 2.5f;
    public float lowjumpMultiplier = 2.0f;

    private Rigidbody rb;


	// Use this for initialization
	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * hoverForce * proportionalHeight;
            rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        if (rb.velocity.y <= 0)
        {
            rb.velocity += Vector3.up * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowjumpMultiplier - 1) * Time.deltaTime;
        }
    }
}

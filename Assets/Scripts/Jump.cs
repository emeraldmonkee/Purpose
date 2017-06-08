using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;

    public bool jumpEnabled;

    public bool jumpPauseState = false;

    private void Awake()
    {
        jumpEnabled = true;
    }

    public void JumpUnpause()
    {
        jumpPauseState = false;
    }

    public void Add_Velocity()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        StartCoroutine(TimerEnumerator());
    }

    IEnumerator TimerEnumerator()
    {
        yield return new WaitForSeconds(1.5f);
        jumpEnabled = true;
    }
 
	void Update ()
    {
        if (jumpPauseState == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (jumpEnabled == true)
                {
                    Add_Velocity();
                    jumpEnabled = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jumpPauseState = true;
        }
    }

}

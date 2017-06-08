using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour_Pulse : MonoBehaviour
{
    public Component jumpLight;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpLight.GetComponent<Light>();
        }
	}
}

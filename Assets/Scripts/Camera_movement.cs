using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    private bool LookAround;
    private bool PausedLooking = false;

    public GameObject character;

    
	// Use this for initialization
	void Start ()
    {
        character = this.transform.parent.gameObject;
        LookAround = true;
	}

    public void PasuedLookingOff()
    {
        PausedLooking = false;
    }

	
	// Update is called once per frame
	void Update ()
    {
        if (PausedLooking == false)
        {
            if (LookAround == true)
            {

                var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

                md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

                mouseLook += smoothV;

                mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            }


            if (Input.GetKeyDown(KeyCode.V))
            {
                transform.Translate(0, 0.5f, -2);
                transform.Rotate(10, 0, 0);
                LookAround = false;
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                transform.Rotate(-10, 0, 0);
                transform.Translate(0, -0.5f, 2);

                LookAround = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausedLooking = true;
        }
    }
}

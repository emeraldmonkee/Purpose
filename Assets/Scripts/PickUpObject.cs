using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject CarriedObject;

    private bool Carrying = false;

    public float distance = 5;
    public float smooth = 2;

	void Start ()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	void Update ()
    {
		if (Carrying)
        {
            Carry(CarriedObject);
            checkDrop();
        }
        else
        {
            pickUp();
        }
	}
    
    void Carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime*smooth);
    }
    void pickUp()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    Carrying = true;
                    CarriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        Carrying = false;
        CarriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        CarriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        CarriedObject = null;

        
    }
}

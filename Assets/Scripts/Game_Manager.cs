using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject pausepanel;

    public bool Paused = false;

    public Camera_movement _Camera_movement;

    public Jump _Jump;

    void Awake()
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void ReturnToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pausepanel.SetActive(false);
        Time.timeScale = 1;
        _Camera_movement.PasuedLookingOff();
        _Jump.JumpUnpause();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pausepanel.SetActive(true);
        }
    }
}

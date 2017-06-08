using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public void Start_Btn(string Tutorial)
    {
        SceneManager.LoadScene(Tutorial);
    }
    public void Exit_Btn()
    {
        Application.Quit();
    }
    public void Main_Menu_Btn()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

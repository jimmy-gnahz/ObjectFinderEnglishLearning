using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{

    public AudioSource buttonPress;
    //public GameObject bestScore;

    public void LoadGame(int index)
    {
        if (index == 1)
        {

        }
        else if (index == 2)
        {

        }
        else if (index == 3)
        {
            RedirectManager.redirectToLevel = 2;
            SceneManager.LoadScene(2);
        }
        else if (index == 4)
        {

        }
        else if (index == 5)
        {

        }
        else if (index == 6)
        {

        }
    }

    public void QuitGame()
    {
        buttonPress.Play();
        Application.Quit();
    }
}
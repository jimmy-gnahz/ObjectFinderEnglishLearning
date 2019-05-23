using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public bool gamePaused = false;
    public AudioSource BGM;
    public GameObject pauseMenu;
    public GameObject FPC;

    void Update()
    {
        //Debug.Log(PlayerCasting.currentDirection);
        //Debug.Log()
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(false);
                Time.timeScale = 0;
                gamePaused = true;
                BGM.Pause();
                pauseMenu.SetActive(true);
            }
            else
            {
                resumeGame();  
            }
        }
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        BGM.UnPause();
        gamePaused = false;
        Time.timeScale = 1;
        FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
    }

    public void restartLevel()
    {
        pauseMenu.SetActive(false);
        BGM.UnPause();
        gamePaused = false;
        Time.timeScale = 1;
        FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.SetCursorLock(true);
        SceneManager.LoadScene(RedirectManager.redirectToLevel);
    }

    public void quitToMenu()
    {
        pauseMenu.SetActive(false);
        BGM.UnPause();
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
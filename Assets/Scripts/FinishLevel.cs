using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject levelMusic;
    public AudioSource levelComplete;
    public GameObject levelTimer;
    public GameObject levelTimer2;
    public GameObject timeLeft;
    public GameObject remainingHealth;
    public GameObject totalScore;
    public GameObject returnToMenuButton;

    public void Finish()
    {
        levelMusic.SetActive(false);
        levelTimer.SetActive(false);
        levelTimer2.SetActive(false);
        levelComplete.Play();
        StartCoroutine(CalculateScore());
    }

    IEnumerator CalculateScore()
    {

        timeLeft.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        remainingHealth.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        totalScore.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        returnToMenuButton.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}

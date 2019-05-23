using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

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
        int timeCalc = Convert.ToInt32(levelTimer.GetComponent<Text>().text);
        int healthCalc = GameManager.currentHealth;
        int totalCalc = timeCalc + 30 * healthCalc;

        timeLeft.GetComponent<Text>().text = "Time Left: " + timeCalc;
        remainingHealth.GetComponent<Text>().text = "Health Left x 30: " + healthCalc;
        totalScore.GetComponent<Text>().text = "Total Score: " + totalCalc;

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
